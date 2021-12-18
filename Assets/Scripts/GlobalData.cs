using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static Level CurrentLevel { get; set; } = new Level("test_level", Difficulty.Normal);
}
