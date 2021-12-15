using System;
using UnityEngine;

public class MikicStageSleeping : MonoBehaviour, IBossStage
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