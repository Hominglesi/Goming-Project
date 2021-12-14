using System;
using UnityEngine;

public static partial class PatternFactory
{
    public static PatternBase AttachSingle(GameObject parent, PatternArgs args)
    {
        var pattern = parent.AddComponent<PatternSingle>();
        pattern.Initialize(args);
        return pattern;
    }
}
