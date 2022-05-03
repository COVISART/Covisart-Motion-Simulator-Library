using System.ComponentModel;
using CovisartMotionSimulatorLibrary.TwinCatNotification;
using EnvDTE;
//using TCatSysManagerLib;
using TwinCAT.Ads;
using Thread = System.Threading.Thread;

namespace CovisartMotionSimulatorLibrary
{

    /// <summary>
    /// Bu sınıf <see cref="TcAdsClient"/> sınıfının COVISART SIMULATOR projesi için özelleştirilmiş komutlarından oluşmaktadır. 
    /// </summary>
    public partial class TwinCatHelper
    {
        public AdsClient AdsClient;
        public TwinCatVariable<bool> RestartTwincat;
        /// <summary>
        /// Motor değişkenlerinin barındaran değişken.
        /// <para>Motorlara ulaşmak için "X","Y","Z" key'lerini kullanabilirsiniz.</para>
        /// </summary>
        public Dictionary<string,Engine> engines = new Dictionary<string, Engine>();

        //private ITcSysManager7 _sysMan;
        private readonly EnvDTE.Solution _sol;

        private readonly bool _isTcXaeShellWorking;
        private readonly DTE? _dte;
        public TwinCatHelper(string solutionPath = null)
        {
            var connectionChecker = new BackgroundWorker();
            connectionChecker.DoWork += ConnectionChecker_DoWork;
            connectionChecker.RunWorkerAsync();

            if (string.IsNullOrWhiteSpace(solutionPath)) return;
            try
            {
                var t = Type.GetTypeFromProgID("TcXaeShell.DTE.15.0");
                if (t != null) _dte = (DTE)Activator.CreateInstance(t)!;
                if (_dte != null)
                {
                    _dte.SuppressUI = true;
                    _dte.MainWindow.Visible = false;
                    _sol = _dte.Solution;
                }

                _sol?.Open(solutionPath);
                _isTcXaeShellWorking = true;
            }
            catch (Exception)
            {
                _isTcXaeShellWorking = false;
            }
        }

        public bool IsHardResetRequired;
        public event Action<bool> OnTwincatConnectionStateChanged;
        private void ConnectionChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                try
                {
                    engines["X"].CurrentPosition.Get();
                    if (!TwinCatState)
                    {
                        OnTwincatConnectionStateChanged?.Invoke(true);
                    }
                    TwinCatState = true;
                }
                catch (AdsErrorException ex)
                {
                    if (ex.ErrorCode == AdsErrorCode.PortDisabled)
                    {
                        IsHardResetRequired = true;
                    }

                    IsHardResetRequired = true;
                    if (TwinCatState)
                    {
                        OnTwincatConnectionStateChanged?.Invoke(false);
                    }
                    TwinCatState = false;

                }
                catch (Exception)
                {
                    TwinCatState = false;
                    IsHardResetRequired = true;
                }
                Thread.Sleep(500);
            }
        }

        public void QuitDte()
        {
            if (_isTcXaeShellWorking)
            {
                _dte?.Quit();
            }
        }

        private TwinCatNotifierManager _twinCatNotifierManager;

        public bool TwinCatState;

        /// <summary>
        /// PLC ile bağlantı kurmak için gerekli komut.
        /// </summary>
        /// <param name="netId"></param>
        /// <param name="srvPort"></param>
        /// <returns>Bağlantı hatasız bir şekilde kurulursa <c>true</c> değerini döndürür.</returns>
        public bool OpenConnection(string netId, int srvPort)
        {
            if (TwinCatState) return TwinCatState;//throw new CovisartWarningException("The connection is already exist.");
            var start = DateTime.Now;
            ClearRamIfExist();
            AdsClient = new AdsClient();
            if(netId.Length<7)
                AdsClient.Connect(srvPort);
            else
                AdsClient.Connect(netId, srvPort);

            var isConnected = AdsClient.IsConnected;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine((DateTime.Now - start).TotalMilliseconds + " Ads Connect time.");

            if (!isConnected) return true;
            _twinCatNotifierManager = new TwinCatNotifierManager(AdsClient);
            engines.Add("X", new Engine(AdsClient, "X", _twinCatNotifierManager, engineInfo: "Pitch"));
            //engines["X"].CalibrationDone.ValueChanged += CalibrationDone_ValueChanged;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Axis 1 connected");
            Console.ForegroundColor = ConsoleColor.White;
            engines.Add("Y", new Engine(AdsClient, "Y", _twinCatNotifierManager, engineInfo: "Roll"));
            // engines["Y"].CalibrationDone.ValueChanged += CalibrationDone_ValueChanged;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Axis 2 connected");
            Console.ForegroundColor = ConsoleColor.White;
            engines.Add("Z", new Engine(AdsClient, "Z", _twinCatNotifierManager, engineInfo: "Yaw"));
            //engines["Z"].CalibrationDone.ValueChanged += CalibrationDone_ValueChanged;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Axis 3 connected");
            Console.ForegroundColor = ConsoleColor.White;
            RestartTwincat = new TwinCatVariable<bool>(AdsClient, "HARD_RESTART", null!, null);
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                try
                {
                    _twinCatNotifierManager.InitializeNotifier();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }).Start();
            try
            {
                DisableExactPosition();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                PowerOff();
            }
            catch (Exception e)
            {            
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Notifier Manager Initialized");
            Console.ForegroundColor = ConsoleColor.White;
            return true;

        }

        //private void CalibrationDone_ValueChanged(TwinCatVariable<bool> obj)
        //{
        //    if (obj.Value)
        //    {
        //        engines[obj.EngineType].CalibrateAxis.Set(false);
        //    }
        //}

        /// <summary>
        /// Bağlantı koptuğunda veya kapatıldığında gerekli nesneleri siler.
        /// </summary>
        private void ClearRamIfExist()
        {
            try
            {
                AdsClient.Close();
                AdsClient.Dispose();

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            _twinCatNotifierManager.ClearNotifiers();

            if (engines.Count>0)
            {
                engines.Clear();
            }
        }

        /// <summary>
        /// Motorlardaki elektiriği açıksa kapatır, ardından bağlantıyı sonlandırır. 
        /// </summary>
        /// <returns></returns>
        public bool CloseConnection()
        {
            PowerOff();
            ClearRamIfExist();
            return true;
        }

        /// <summary>
        /// PLC'ye motorlara elektirik göndermesini sağlar. PLC bağlantısı gereklidir.
        /// </summary>
        public void PowerOn()
        {
            if (!TwinCatState) throw new CovisartWarningException("Connection does not opened.");
            
            foreach (var item in engines)
                item.Value.Power.Set(true);
        }

        /// <summary>
        /// PLC'ye motorlara elektirik göndermesini sağlar. Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void PowerOff()
        {
            if (!TwinCatState) throw new CovisartWarningException("Connection is not opened.");

            if (TwinCatState)
            {
                foreach (var item in engines)
                {
                    item.Value.Power.Set(false);
                }
            }
        }


        /// <summary>
        /// PLC'ye beliritilen motora elektirik göndermesini sağlar. Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void PowerOn(string type)
        {
            if (!TwinCatState) throw new CovisartWarningException("Connection is not opened.");
            PowerOn(engines[type]);

        }

        /// <summary>
        /// PLC'ye motorlara elektirik göndermesini sağlar. Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void PowerOn(Engine engine)
        {
            if (!TwinCatState) throw new CovisartWarningException("Connection is not opened.");

            if (TwinCatState)
            {
                engine.Power.Set(true);
            }
        }




        /// <summary>
        /// PLC'ye motorlara elektirik göndermesini sağlar. Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void PowerOff(string engineType)
        {
            if (!TwinCatState) throw new CovisartWarningException("Connection is not opened.");
            PowerOff(engines[engineType]);
        }



        /// <summary>
        /// PLC'ye motorlara elektirik göndermesini sağlar. Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void PowerOff(Engine engine)
        {
            if (TwinCatState)
            {
                engine.Power.Set(false);
            }
            else
            {
                throw new CovisartWarningException("Connection is not opened.");
            }
        }

        /// <summary>
        /// Bütün motorları verilen pozisyon komutlarına hazır hale getirir. Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void EnableExactPosition()
        {
            if (!TwinCatState) throw new CovisartWarningException("Connection is not opened.");
            if (TwinCatState)
            {
                foreach (var item in engines)
                {
                    EnableExactPosition(item.Value);
                }
            }
        }

        public void EnableExactPositionAxis(string anyString)
        {
            if (TwinCatState)
            {
                foreach (var item in engines)
                {
                    EnableExactPosition(item.Value);
                }
            }
            else
            {
                throw new CovisartWarningException("Connection is not opened.");
            }
        }

        /// <summary>
        /// Bütün motorları verilen pozisyon komutlarına duyarsız hale getirir. Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void DisableExactPosition()
        {
            if (TwinCatState)
            {
                foreach (var item in engines)
                {
                    DisableExactPosition(item.Value);
                }
            }
            else
            {
                throw new CovisartWarningException("Connection is not opened.");
            }
        }

        private void CheckErrorState(Engine engine)
        {
            if (engine.AxisError.Value)
            {
                throw new EngineException(engine, "AxisError", engine.AxisErrorId.Value);
            }

            if (engine.ExactPositionError.Value)
            {
                throw new  EngineException(engine, "ExactPositionError", engine.ExactPositionErrorId.Value);
            }

            if (engine.PowerError.Value)
            {
                throw new  EngineException(engine, "PowerError", engine.PowerErrorId.Value);
            }

            if (engine.ResetErrorStatus.Value)
            {
                throw new  EngineException(engine, "ResetErrorStatus", engine.ResetErrorStatusId.Value);
            }

            if (engine.SetPositionError.Value)
            {
                throw new EngineException(engine, "SetPositionError", engine.SetPositionErrorId.Value);
            }

            if (engine.StopAxisError.Value)
            {
                throw new EngineException(engine, "StopAxisError", engine.StopAxisErrorId.Value);
            }
        }

        /// <summary>
        /// Motoru pozisyon komutlarına hazır hale getirir. Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void EnableExactPosition(Engine engine)
        {
            if (!TwinCatState)
            {
                throw new CovisartWarningException("Connection is not opened.");
            }

            if (!engine.Powered.Value)
            {
                throw new CovisartWarningException("Engine " + engine.engineType + " is not powered.");
            }

            if (!engine.CalibrationDone.Value)
            {
                throw new CovisartWarningException("Engine " + engine.engineType + " is not calibrated.");
            }

            CheckErrorState(engine);

            engine.EnExactPosition.Set(true);


        }


        /// <summary>
        /// Motoru verilen pozisyon komutlarına duyarsız hale getirir. Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void DisableExactPosition(Engine engine)
        {

            if (TwinCatState)
            {
                engine.EnExactPosition.Set(false);
            }
            else
            {
                throw new CovisartWarningException("Connection is not opened.");
            }
           
        }

        /// <summary>
        /// Motorlar hata durumuna düştüğünde hata koşulları gözden geçirilip düzeltildikten sonra bu fonksiyon ile hata durumu düzeltildiği motorlara bildirilir.  Plc bağlantısının açık olması gerekir. Bağlanıyı açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        public void ResetError()
        {

            if (!TwinCatState) throw new CovisartWarningException("Connection is not opened.");
            foreach (var item in engines)
            {
                ResetError(item.Value);
            }
        }


        /// <summary>
        /// İlgili motor hata durumuna düştüğünde hata koşulları gözden geçirilip düzeltildikten sonra bu fonksiyon ile hata durumu düzeltildiği motorlara bildirilir.  
        /// Plc bağlantısının açık olması gerekir. 
        /// Plc bağlantısını açmak için <see cref="OpenConnection(string, int)"/>
        /// </summary>
        /// <param name="engine"></param>
        public void ResetError(Engine engine)
        {
            var variables = engine.GetType().GetProperties().Where(x => x.PropertyType == typeof(TwinCatErrorVariable))
                .Select(item => (TwinCatErrorVariable)item.GetValue(engine)!).ToList();
            if (variables.Count(x => x.Value) <= 0)
            {
                throw new CovisartWarningException("No error detected!");
            }
            if (!TwinCatState)
            {
                throw new CovisartWarningException("Connection is not opened.");
            }
            engine.ResetError.Set(true);
            engine.ResetError.Set(false);

        }

        /// <summary>
        /// Motorların sıfır(0) noktasına gitmesini sağlar. <see cref="Engine.EnExactPosition"/> değişkeninin <c>False</c> olması gerekmektedir ve motorların elektiriğe bağlanmış olması gerekmetedir. 
        /// Plc bağlantısının açık olması gerekir. 
        /// <para>Plc bağlantısını açmak için <see cref="OpenConnection"/> komutunu çağrınız.</para> 
        /// <para> Motorlara güç vermek için <see cref="PowerOn"/> komutunu çağrınız.</para> 
        /// <para> EnExactPosition'ı açmak için <see cref="EnableExactPosition"/> komutunu çağrınız. </para>
        /// 
        /// </summary>
        public void Calibrate()
        {

            if (TwinCatState)
            {

                foreach (var item in engines)
                {
                    Calibrate(item.Value);
                }
            }
            else
            {
                throw new CovisartWarningException("Connection is not opened.");
            }
        }



        /// <summary>
        /// Verilen motorun sıfır(0) noktasına gitmesini sağlar. <see cref="Engine.EnExactPosition"/> değişkeninin <c>False</c> olması gerekmektedir ve motorların elektiriğe bağlanmış olması gerekmetedir. 
        /// Plc bağlantısının açık olması gerekir. 
        /// <para>Plc bağlantısını açmak için <see cref="OpenConnection"/> komutunu çağrınız.</para> 
        /// <para> Motorlara güç vermek için <see cref="PowerOn"/> komutunu çağrınız.</para> 
        /// <para> EnExactPosition'ı açmak için <see cref="EnableExactPosition"/> komutunu çağrınız. </para>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Calibrate(Engine engine)
        {
            if (!engine.Powered.Value)
            {
                throw new CovisartWarningException("You cannot calibrate system when engines are not powered!");
            }

            CheckErrorState(engine);
            if (engine.EnExactPosition.Value)
            {
                throw new CovisartWarningException("You can't calibrate system when realtime system is activated!");
            }
            if (TwinCatState)
            {
                engine.CalibrateAxis.Set(!engine.CalibrationDone.Value);
            }
            else
            {
                throw new CovisartWarningException("Connection is not opened.");
            }
           
        }

        /// <summary>
        /// Verilen motorun sıfır(0) noktasına gitmesini sağlar. <see cref="Engine.EnExactPosition"/> değişkeninin <c>False</c> olması gerekmektedir ve motorların elektiriğe bağlanmış olması gerekmetedir. 
        /// Plc bağlantısının açık olması gerekir. 
        /// <para>Plc bağlantısını açmak için <see cref="OpenConnection"/> komutunu çağrınız.</para> 
        /// <para> Motorlara güç vermek için <see cref="PowerOn"/> komutunu çağrınız.</para> 
        /// <para> EnExactPosition'ı açmak için <see cref="EnableExactPosition"/> komutunu çağrınız. </para>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Calibrate(string engineType)
        {
            if (TwinCatState)
            {
                Calibrate(engines[engineType]);
            }
            else
            {
                throw new CovisartWarningException("Connection is not opened.");
            }
        }

        /// <summary>
        /// Plc yi yeniden başlatır. Plc bağlantısı gerektirir.
        /// <para>Plc bağlantısını açmak için <see cref="OpenConnection"/> komutunu çağrınız.</para> 
        /// </summary>
        /// <returns></returns>
        public string RestartTwinCat()
        {
            try

            {
                if (TwinCatState)
                {
                    RestartTwincat.Set(true); 
                }
                else
                {
                    throw new CovisartWarningException("Connection is not opened.");
                }

                return "Başarılı!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /*/// <summary>
        /// Plc yi yeniden başlatır. Xae shell kullanır.
        /// </summary>
        public object HardRestartTwinCat()
        {
            try
            {
                if (!_isTcXaeShellWorking)
                {
                    return "TcXaeShell couldn't open the 'Restart.sln' file!";
                }
                if (_sol == null)
                {
                    return "Restart solution path can not be null.";
                }

                var pro = _sol.Projects.Item(1);
                _sysMan = (ITcSysManager7)pro.Object;
                _sysMan.StartRestartTwinCAT();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }*/


    }

    
}
