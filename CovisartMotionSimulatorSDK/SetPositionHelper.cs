using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace CovisartMotionSimulatorSDK
{
    /// <summary>
    /// Bu sınıf motorların pozisyonunu değiştirmeye çalıştığınızda ayrı bir thread ile bu pozisyonları filtreler ve  <see cref="TwinCatHelper"/>  aracılığıyla sonucu motorlara gönderir.
    /// <para>Bu filtre işlemi verilen koordinatlara en yakın yolu izleyecek şekilde gitmeyi hedefler.</para>
    /// <code>
    /// SetPositionHelper helper = new SetPositionHelper(<see cref="TwinCatHelper"/>:twinCatHelper);
    /// </code>
    /// <code>helper.Start();</code>
    /// <code>
    /// helper.Axises = new Dictionary(string,double){("X",0.0),("Z",0.0),("Y",0.0)}
    /// </code>
    /// Yukarıdaki kodları kullandığınızda basitçe motoru 0 noktasına hareket ettirmiş olursunuz.
    /// </summary>
    public class SetPositionHelper : IDisposable
    {
        public BackgroundWorker BackgroundWorker = new BackgroundWorker();
        public CoSimOpenTrackClient coSimOpentrackClient = new CoSimOpenTrackClient();
        readonly TwinCatHelper twinCatHelper;

        public Dictionary<string, double> Axises = new Dictionary<string, double>();
        public SetPositionHelper(TwinCatHelper adsManager )
        {
            BackgroundWorker.DoWork += BackgroundWorker_DoWork;
            BackgroundWorker.WorkerSupportsCancellation = true;
            this.twinCatHelper = adsManager;

            //foreach (var engine in twinCatHelper.engines)
            //{
            //    engine.Value.CurrentPosition.ValueChanged += CurrentPosition_ValueChanged;
            //}
        }


        public void Start()
        {
            BackgroundWorker.RunWorkerAsync();
            Console.WriteLine(!coSimOpentrackClient.Connect()
                ? " OpenTrack can not connected"
                : " OpenTrack connected");
        }


        public void Stop()
        {
            BackgroundWorker.CancelAsync();
            coSimOpentrackClient.Stop();
        }
   
        static double NearestPositionCalculator(double axis, double currentPosition)
        {
            int currentTurn = (int)(currentPosition / 360);

            double realAxisDegree = axis % 360;

            var x1 = currentTurn * 360 + realAxisDegree;
            var x2 = (currentTurn + 1) * 360 + realAxisDegree;
            var x3 = (currentTurn - 1) * 360 + realAxisDegree;
            var x4 = (currentTurn - 2) * 360 + realAxisDegree;

            var absX1 = Math.Abs(currentPosition - x1);
            var absX2 = Math.Abs(currentPosition - x2);
            var absX3 = Math.Abs(currentPosition - x3);
            var absX4 = Math.Abs(currentPosition - x4);

            var min = Math.Min(Math.Min(absX1, absX2), absX3);
            min = Math.Min(min, absX4);
            if (absX1 == min)
            {
                return x1;
            }

            if (absX2 == min)
            {
                return x2;
            }

            if(absX3 == min)
            {
                return x3;
            }

            return x4;
        }
        static float map (float value, float from1, float to1, float from2, float to2) {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            /*DateTime beginTime = DateTime.Now;
            int counter = 0;*/
            while (!BackgroundWorker.CancellationPending)
            {
                if (!twinCatHelper.TwinCatState)
                {
                    Stop();
                }
                try
                {
                    //Console.WriteLine(" Data:");
                    foreach (var item in twinCatHelper.engines)
                    {
                        var engine = item.Value;
                        if (Axises.Count> 0 && engine.EnExactPosition.Value)
                        {
                            var result = NearestPositionCalculator(Axises[engine.engineType], engine.CurrentPosition.Value);
                            if (!twinCatHelper.TwinCatState)
                            {
                                Stop();
                            }
                            else
                            {
                                engine.Position.Set(result);
                                //Console.Write(" X:" + Axises[engine.engineType]);
                                //if (engine.Name == "Yaw") yaw = map((float)result, -180, 180, -0.65f, 0.65f) * (-1);
                                //if (engine.Name == "Pitch") pitch = map((float)result, -90, 90, -0.65f, 0.65f) * (-1);
                                //if (engine.Name == "Roll") roll = map((float)Axises[engine.engineType], -180, 180, -3.2f, 3.2f);
                                //if (!coSimOpentrackClient.isConnected()) coSimOpentrackClient.SetString(0, roll, 0); //coSimOpentrackClient.Connect();
                            }

                        }
                    }

                }
                catch (Exception)
                {
                    // ignored
                }
                Thread.Sleep(1);
                /*var resulTime = DateTime.Now - beginTime;
                counter++;
                if (resulTime.TotalSeconds >= 1)
                {
                    Console.WriteLine(counter);
                    beginTime = DateTime.Now;
                    counter = 0;
                }*/

            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    BackgroundWorker.CancelAsync();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SetPositionHelper()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}
