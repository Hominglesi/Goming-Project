using System;
using UnityEngine;

public class MikicStageEndAnimation : MonoBehaviour, IBossStage
{
    float duration = 3f;
    float durationTimer;
    float exposionSize = 1.7f;

    float exposionRate = 0.12f;
    float exposionTimer;

    public void SetActive(bool active)
    {
        enabled = active;
        if (active) OnAwake();
    }

    public void OnAwake()
    {
        gameObject.GetComponent<MikicBossLogic>().IsDamageable = false;
        durationTimer = 0;
        exposionTimer = 0;
    }

    public void Update()
    {
        exposionTimer += Time.deltaTime;
        if (exposionTimer > exposionRate)
        {
            var particleX = transform.position.x + UnityEngine.Random.Range(-exposionSize, exposionSize);
            var particleY = transform.position.y + UnityEngine.Random.Range(-exposionSize, exposionSize);
            ParticleFactory.Create(ParticleType.Explosion, new Vector2(particleX, particleY));
            exposionTimer = 0;
        }
        

        durationTimer += Time.deltaTime;
        if(durationTimer > duration) gameObject.GetComponent<MikicBossLogic>().SetStage(MikicStages.IntroAnimation);
    }
}

