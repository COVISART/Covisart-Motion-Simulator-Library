using CovisartMotionSimulatorLibrary.TwinCatNotification;
using TwinCAT.Ads;

namespace CovisartMotionSimulatorLibrary
{
    /// <summary>
    /// Plc'deki değişkenlerin iletişimini sağlayan <c>Generic Class</c>
    /// </summary>
    public class TwinCatVariable<T> : ITwinCatVariable
    {
        private readonly AdsClient _adsClient;
        /// <summary>
        /// Plc Variable ID in PlC runtime.
        /// </summary>
        public uint TargetId { get; set; }
        /// <summary>
        /// Global name of plc variable. 
        /// </summary>
        public string TargetTagName { get; set; }
        /// <summary>
        /// Value of plc variable. This value automatically changes when TwincatVariable added a TwinCatNotifierManager
        /// <para><see cref="TwinCatNotifierManager"/> whenever a value change in TwinCat Plc module, TwinCatNotifierManager will trace them. </para>
        /// </summary>
        public T Value
        {
            get => (T)_Value;
            set => _Value = value;
        }
        /// <summary>
        /// If a settings value changed, restart required.
        /// </summary>
        public bool isSettings { get; set; } = false;
        public string settingCategoryName { get; set; }
        public object _Value { get; set; }
        public string ValueType { get; set; }
        public string EngineType { get; set; }
        public TwinCatVariable(AdsClient adsClient, string targetTag, string engineType)
        {
            EngineType = engineType;
            _adsClient = adsClient;

            TargetTagName = "." + targetTag + engineType;

            TargetId = adsClient.CreateVariableHandle(TargetTagName);
            //Console.WriteLine("Two:" + TargetTagName);

            ValueType = typeof(T).Name;
        }

        public TwinCatVariable(AdsClient adsClient, string targetTag, string engineType, List<TwinCatNotifier> notificationList)
            : this(adsClient, targetTag, engineType)
        {
            notificationList?.Add(new TwinCatNotifier(typeof(T), TargetTagName, ValueChanger));
        }
        public T Get()
        {
            return (T)_adsClient.ReadAny(TargetId, typeof(T));
        }

        public void Set(T value)
        {
            _adsClient.WriteAny(TargetId, value);
        }

        public void _Set(object value)
        {
            _adsClient.WriteAny(TargetId, value);
        }

        protected virtual void ValueChanger(object value)
        {
            Value = (T)value;
            ValueChanged?.Invoke(this);
            //Console.WriteLine(TargetTagName + ": " + value);
        }

        public event Action<TwinCatVariable<T>> ValueChanged;
    }

    public class TwinCatErrorVariable : TwinCatVariable<bool>
    {
        public static event Action<TwinCatErrorVariable> ErrorNotifier;
        private TwinCatVariable<UInt16> ErrorIdVariable;
        public string ErrorDescription { get; internal set; }
        public UInt16 ErrorId { get; internal set; }
        public TwinCatErrorVariable(AdsClient adsClient, string targetTag, string engineType, TwinCatNotifierManager notificationList, TwinCatVariable<UInt16> ErrorIdVariable) 
            : base(adsClient, targetTag, engineType, notificationList)
        {
            this.ErrorIdVariable = ErrorIdVariable;
        }



        protected override void ValueChanger(object value) 
        {
            base.ValueChanger(value);

            if (base.Value)
            {
                ErrorId = ErrorIdVariable.Value;
                ErrorDescription = ErrorCodes.Get(ErrorIdVariable.Value).Description;
                ErrorNotifier?.Invoke(this);
            }
            else
            {
                ErrorId = 0;
                ErrorDescription = null;
            }
        }
    }
}
