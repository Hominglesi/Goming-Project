using System;
using UnityEngine;

public class MikicStageEndAnimation : MonoBehaviour, IBossStage
{
    public void SetActive(bool active)
    {
        enabled = active;
        if (active) OnAwake();
    }

    public void OnAwake()
    {
        gameObject.GetComponent<MikicBossLogic>().IsDamageable = false;
    }

    public void Update()
    {

    }
}

