using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IEnemyPattern
{
    public bool IsCompleted { get; set; }

    public void Update();
}

