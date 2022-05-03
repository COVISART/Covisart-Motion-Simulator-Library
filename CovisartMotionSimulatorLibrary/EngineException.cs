
namespace CovisartMotionSimulatorLibrary
{

    public partial class TwinCatHelper
    {
        public class EngineException : Exception
        {
            public string engineType { get; internal set; }
            public string ErrorSource { get; internal set; }
            public string ErrorType { get; internal set; }
            public int ErrorId { get; internal set; }
            public string ErrorDescription { get;internal set; }
            public EngineException(Engine engine,string ErrorSource, ushort ErrorId) :base(ModifyMessage(engine, ErrorSource, ErrorId))
            {
                engineType = engine.engineType;
                this.ErrorSource = ErrorSource;
                this.ErrorId = ErrorId;

                var ErrorObj = ErrorCodes.Get(ErrorId);
                this.ErrorDescription = ErrorObj.Description;
                this.ErrorType = ErrorObj.Type.ToString();
                
            }

            private static string ModifyMessage(Engine engine, string ErrorSource, ushort ErrorId)
            {
                var ErrorObj = ErrorCodes.Get(ErrorId);

                if (ErrorObj.Description != null)
                    return "Motors are in error state!\n ErrorSource: " + ErrorSource + ",\n ErrorCode: " + engine.StopAxisErrorId.Value + ", \nError description: " + ErrorObj.Description;

                return "Motors are in error state! ErrorSource: " + ErrorSource + ", ErrorCode: " + engine.StopAxisErrorId.Value;
            }
        }


    }

    
}
