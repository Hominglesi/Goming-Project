using System;
using UnityEngine;

public static partial class PatternFactory
{
    public static PatternBase AttachComponent(GameObject parent, PatternArgs args)
    {
        switch (args.Type)
        {
            case PatternTypes.Single:
                return AttachSingle(parent, args);
            case PatternTypes.Spread:
                return AttachSpread(parent, args);
            default:
                throw new NotImplementedException($"Pattern Factory for type '{args.Type}' is not implemented");
        }
    }
}

