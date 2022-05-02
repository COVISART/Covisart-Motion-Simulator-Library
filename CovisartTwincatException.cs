namespace CovisartMotionSimulatorLibrary
{
    [Serializable]
    public class CovisartTwincatException : Exception
    {
        private TwinCatErrorVariable twincatVariable;

        public CovisartTwincatException(TwinCatErrorVariable twincatVariable)
            :base("There is error in engine. Engine variable tag name: " + twincatVariable.TargetTagName + 
                 "\nError description: " + twincatVariable.ErrorDescription + 
                 "\nError Id: " + twincatVariable.ErrorId)
        {
            this.twincatVariable = twincatVariable;
        }
    }
}