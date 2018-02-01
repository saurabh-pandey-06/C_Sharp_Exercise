namespace FutureWonder.Exercises.Configuration
{
    public enum ValueType
    {
        ValueNone,
        ValueInt,
        ValueDouble,
        ValueString
    }

    public struct ConfigValue
    {
        public string Value { get; set; }
        public ValueType ValueType { get; set; }
    }
}