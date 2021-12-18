using System;
using UnityEngine;

public static partial class PatternFactory
{
    public static PatternBase AttachComponent(GameObject parent, PatternArgs args)
    {
        var componentType = Type.GetType("Pattern" + args.Type);
        
        var pattern = (PatternBase)parent.AddComponent(componentType);
        pattern.Initialize(args);
        return pattern;
        
        /*
        switch (args.Type)
        {
            case PatternTypes.Single:
                return AttachSingle(parent, args);
            case PatternTypes.Spread:
                return AttachSpread(parent, args);
            case PatternTypes.MikicHair:
                return AttachMikicHair(parent, args);
            case PatternTypes.MikicSleep:
                return AttachMikicSleep(parent, args);
            default:
                
        }*/
    }
}

