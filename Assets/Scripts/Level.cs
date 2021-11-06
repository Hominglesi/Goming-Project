using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level
{
    public string Name { get; set; }
    public Difficulty Difficulty { get; set; }

    public Level(string name, Difficulty diff)
    {
        Name = name;
        Difficulty = diff;
    }
}

public enum Difficulty
{
    Easy,
    Normal,
    Hard,
    Insane
}
