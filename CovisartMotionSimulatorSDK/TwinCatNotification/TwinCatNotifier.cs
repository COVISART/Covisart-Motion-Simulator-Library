using System;

namespace CovisartMotionSimulatorSDK.TwinCatNotification
{
    public class TwinCatNotifier
    {
        public Type type;

        public TwinCatVariable<object> twincatVariable;
        public string targetTagName;
        public Action<object> valueChanger;

        public TwinCatNotifier(Type type, string targetTagName, Action<object> valueChanger)
        {
            this.type = type;
            this.targetTagName = targetTagName;
            this.valueChanger = valueChanger;
        }
    }
}