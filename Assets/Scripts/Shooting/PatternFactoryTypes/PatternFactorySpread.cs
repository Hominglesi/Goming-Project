using System;
using UnityEngine;

public static partial class PatternFactory
{
    public static PatternBase AttachSpread(GameObject parent, PatternArgs args)
    {
        var pattern = parent.AddComponent<PatternSpread>();
        pattern.Initialize(args);
        return pattern;
    }
}
