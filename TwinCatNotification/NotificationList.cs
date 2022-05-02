using System.Diagnostics;
using System.Text;
using TwinCAT.Ads;

namespace CovisartMotionSimulatorLibrary.TwinCatNotification
{
    /// <summary>
    /// Whenever a value change in TwinCat Plc module, TwinCatNotifierManager will trace them.
    /// </summary>
    public class TwinCatNotifierManager: List<TwinCatNotifier>
    {
        TcAdsClient adsClient;

        public TwinCatNotifierManager(TcAdsClient adsClient) => this.adsClient = adsClient;
        BinaryReader binRead;
        private AdsStream dataStream;
        public void InitializeNotifier()
        {
            dataStream = new AdsStream();
            binRead = new BinaryReader(dataStream, Encoding.ASCII);

            int offset = 0;
            adsClient.AdsNotification += AdsClient_AdsNotification;
            foreach (var item in this)
            {
                var length = 1;//bool

                if (item.type == typeof(double))
                {
                    length = 8;
                }
                if (item.type == typeof(UInt16))
                {
                    length = 2;
                }

                adsClient.AddDeviceNotification(item.targetTagName, dataStream, offset, length, AdsTransMode.OnChange,
                    100, 0, item);

                offset += length;
            }

          
        }

        
        private void AdsClient_AdsNotification(object sender, AdsNotificationEventArgs e)
        {
            try
            {
                e.DataStream.Position = e.Offset;

                TwinCatNotifier notifier = (TwinCatNotifier)e.UserData;

                if (notifier.type == typeof(double))
                {
                    notifier.valueChanger.Invoke(binRead.ReadDouble());
                }
                else if (notifier.type == typeof(UInt16))
                {
                    notifier.valueChanger.Invoke(binRead.ReadUInt16());
                }
                else if (notifier.type == typeof(int))
                {
                    notifier.valueChanger.Invoke(binRead.ReadInt32());
                }
                else if (notifier.type == typeof(bool))
                {
                    notifier.valueChanger.Invoke(binRead.ReadBoolean());
                }
                else
                {
                    Debug.WriteLine(notifier.type);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public void ClearNotifiers()
        {
            try
            {
                dataStream?.Close();
            }
            catch (Exception)
            {
                // ignored
            }

            dataStream?.Dispose();
        }
    }
}
