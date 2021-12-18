using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTimer : MonoBehaviour
{
    private List<KeyValuePair<string, float>> stageDictionary = new List<KeyValuePair<string, float>>();
    private float timer = 0;
    private float totalTime = 0;

    public string CurrentStage
    {
        get
        {
            foreach (var stage in stageDictionary)
            {
                if (timer < stage.Value) return stage.Key;
            }
            return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stageDictionary.Count <= 0) return;

        timer += Time.deltaTime;
        if (timer > totalTime) timer -= totalTime;
    }

    public void AddStage(string stageName, float stageTime)
    {
        stageDictionary.Add(new KeyValuePair<string, float>(stageName, totalTime + stageTime));
        totalTime += stageTime;
    }

    public void Reset()
    {
        stageDictionary.Clear();
        timer = 0;
        totalTime = 0;
    }
}
