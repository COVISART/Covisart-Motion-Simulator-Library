using System;

namespace CovisartMotionSimulatorSDK
{
    [Serializable]
    public class CovisartTwinCatException : Exception
    {
        private TwinCatErrorVariable twincatVariable;

        public CovisartTwinCatException(TwinCatErrorVariable twinCatVariable)
            :base("There is error in engine. Engine variable tag name: " + twinCatVariable.TargetTagName + 
                 "\nError description: " + twinCatVariable.ErrorDescription + 
                 "\nError Id: " + twinCatVariable.ErrorId)
        {
            this.twincatVariable = twinCatVariable;
        }
    }
}