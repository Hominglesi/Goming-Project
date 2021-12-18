using UnityEngine;

public class BossStageBase : MonoBehaviour
{
    public bool IsDamagable
    {
        get{ return gameObject.GetComponent<IBossLogic>().IsDamageable; }
        set{ gameObject.GetComponent<IBossLogic>().IsDamageable = value; }
    }

    public void SetActive(bool active)
    {
        if (active == false && enabled == true) OnDisabled();
        enabled = active;
        if (active) OnAwake();
    }

    public virtual void OnDisabled() { }

    public virtual void OnAwake() { }
}

