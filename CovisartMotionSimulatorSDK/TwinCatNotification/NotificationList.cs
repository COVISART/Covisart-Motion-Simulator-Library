using System;
using System.Collections.Generic;
using System.Diagnostics;
using TwinCAT.Ads;

namespace CovisartMotionSimulatorSDK.TwinCatNotification
{
    /// <summary>
    /// Whenever a value change in TwinCat Plc module, TwinCatNotifierManager will trace them.
    /// </summary>
    public class TwinCatNotifierManager: List<TwinCatNotifier>
    {
        private readonly AdsClient _adsClient;
        public TwinCatNotifierManager(AdsClient adsClient) => this._adsClient = adsClient;
        public void InitializeNotifier()
        {
            _adsClient.AdsNotification +=  AdsClient_AdsNotification;
            foreach (var item in this)
            {
                var length = 1;//bool

                if (item.type == typeof(double))
                    length = 8;
                if (item.type == typeof(ushort))
                    length = 2;

                //_adsClient.AddDeviceNotification(item.targetTagName, dataStream, offset, length, AdsTransMode.OnChange, 100, 0, item);
                _adsClient.AddDeviceNotification(item.targetTagName, length,
                    new NotificationSettings(AdsTransMode.OnChange, 100, 0), item);
            }

          
        }

        
        private void AdsClient_AdsNotification(object sender, AdsNotificationEventArgs e)
        {
            try
            {
                //e.DataStream.Position = e.Offset;
                var memory = e.Data;
                var notifier = (TwinCatNotifier)e.UserData;

                if (notifier != null && notifier.type == typeof(double))
                {
                    notifier.valueChanger.Invoke(BitConverter.ToDouble(memory.ToArray(), 0));
                }
                else if (notifier != null && notifier.type == typeof(ushort))
                {
                    notifier.valueChanger.Invoke(BitConverter.ToUInt16(memory.ToArray(), 0));
                }
                else if (notifier != null && notifier.type == typeof(int))
                {
                    notifier.valueChanger.Invoke(BitConverter.ToInt32(memory.ToArray(), 0));
                }
                else if (notifier != null && notifier.type == typeof(bool))
                {
                    notifier.valueChanger.Invoke(BitConverter.ToBoolean(memory.ToArray(), 0));
                }
                else
                {
                    Debug.WriteLine(notifier);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

    }
}
