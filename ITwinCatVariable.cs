namespace CovisartMotionSimulatorLibrary
{
    public interface ITwinCatVariable
    {
        public string ValueType { get; set; }
        public uint TargetId { get; set; }
        public string TargetTagName { get; set; }
        public object _Value { get; set; }
        public bool isSettings { get; set; }
        public string settingCategoryName { get; set; }

    }

    public class ITwinCatVariableObject: ITwinCatVariable
    {
        public string ValueType { get; set; }
        public uint TargetId { get; set; }
        public string TargetTagName { get; set; }
        public object _Value { get; set; }
        public bool isSettings { get; set; }
        public string settingCategoryName { get; set; }
    }
}
