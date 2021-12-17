using System;
using UnityEngine;

public static partial class PatternFactory
{
    public static PatternBase AttachMikicSleep(GameObject parent, PatternArgs args)
    {
        var pattern = parent.AddComponent<PatternMikicSleep>();
        pattern.Initialize(args);
        return pattern;
    }
}
