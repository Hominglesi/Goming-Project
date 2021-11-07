using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Paths
{
    public static Vector2[] RombusPath { get; internal set; }

    static Paths()
    {
        var playfieldBounds = GameHelper.PlayfieldBounds;
        var playfieldWidth = Vector2.Distance(new Vector2(playfieldBounds.x, 0), new Vector2(playfieldBounds.z, 0));
        var playfieldHeight = Vector2.Distance(new Vector2(0, playfieldBounds.y), new Vector2(0, playfieldBounds.w));


        //Calculate Rombus Path
        var width = playfieldWidth * 0.8f;
        var height = playfieldHeight * 0.3f;
        var topPadding = playfieldHeight * 0.1f;
        RombusPath = new Vector2[] {
            new Vector2((playfieldBounds.x + playfieldBounds.z) / 2 , playfieldBounds.y - topPadding),
            new Vector2(((playfieldBounds.x + playfieldBounds.z) / 2) - (width/2), playfieldBounds.y - topPadding - (height/2)),
            new Vector2((playfieldBounds.x + playfieldBounds.z) / 2, playfieldBounds.y - topPadding - height),
            new Vector2(((playfieldBounds.x + playfieldBounds.z) / 2) + (width/2), playfieldBounds.y - topPadding - (height/2))
        };
    }
}
