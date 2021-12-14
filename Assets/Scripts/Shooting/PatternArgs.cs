public class PatternArgs
{
    public PatternType Type { get; set; }
}

public enum PatternType
{
    Single,
    Multishot,
    Spread
}
