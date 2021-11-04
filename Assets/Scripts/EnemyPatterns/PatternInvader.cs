using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PatternInvader : IEnemyPattern
{
    public bool IsCompleted { get; set; }

    int remaining;
    float spacing;
    float cooldown;

    public PatternInvader(int amount, float spacing)
    {
        remaining = amount;
        this.spacing = spacing;
        IsCompleted = false;
        cooldown = spacing;
    }

    public void Update()
    {
        cooldown += Time.deltaTime * 10;
        if(cooldown >= spacing)
        {
            new SpawnerInvader(new Vector2(-7, 4), 3);
            cooldown = 0;
            remaining--;
            if (remaining == 0) IsCompleted = true;
        }
    }
}

