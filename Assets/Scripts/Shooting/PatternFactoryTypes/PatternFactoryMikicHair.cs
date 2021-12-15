using System;
using UnityEngine;

public static partial class PatternFactory
{
    public static PatternBase AttachMikicHair(GameObject parent, PatternArgs args)
    {
        var pattern = parent.AddComponent<PatternMikicHair>();
        pattern.Initialize(args);
        return pattern;
    }
}
