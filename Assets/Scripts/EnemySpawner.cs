using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Queue<IEnemyPattern> PatternQueue = new Queue<IEnemyPattern>();

    public void SpawnPattern(IEnemyPattern pattern)
    {
        PatternQueue.Enqueue(pattern);
    }

    private void Update()
    {
        if (PatternQueue.Count == 0) return;
        
        var current = PatternQueue.Peek();
        current.Update();
        if (current.IsCompleted)
        {
            PatternQueue.Dequeue();
        }
    }
}
