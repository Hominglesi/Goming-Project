using System;
using UnityEngine;

public class MikicStageEnraged : MonoBehaviour, IBossStage
{
    public void SetActive(bool active)
    {
        enabled = active;
        if (active) OnAwake();
    }

    public void OnAwake()
    {
        gameObject.GetComponent<MikicBossLogic>().IsDamageable = true;
    }

    public void Update()
    {

    }
}