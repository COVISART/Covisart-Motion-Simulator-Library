using System.IO.Pipes;
using System.Text;

namespace CovisartMotionSimulatorLibrary
{
    public class CoSimOpentrackClient
    {
        private readonly NamedPipeClientStream _pipeClient =
           new NamedPipeClientStream(".", "cv_freetracker", PipeDirection.Out);

        public void Set(int target, int value)
        {
            try
            {
                var b = Encoding.ASCII.GetBytes(target + "/" + value + "\0");
                _pipeClient.Write(b, 0, b.Length);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public void SetString(float yaw, float roll, float pith)
        {
            try
            {
                var output = yaw + "/" + roll + "/" + pith + "\0";
                var b = Encoding.ASCII.GetBytes(output);
                _pipeClient.Write(b, 0, b.Length);
                //Console.WriteLine("Output:" + output);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public bool Connect()
        {
            try
            {
                _pipeClient.Connect(2000);
                return true;

            }
            catch (TimeoutException exp)
            {

                Console.WriteLine(exp.Message);
                return false;
            }
        }

        internal void Stop()
        {
            _pipeClient.Close();
        }
        public bool isConnected() => _pipeClient.IsConnected;

    }
}
