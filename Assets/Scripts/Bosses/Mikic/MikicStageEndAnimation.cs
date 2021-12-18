using System;
using UnityEngine;

public class MikicStageEndAnimation : BossStageBase, IBossStage
{
    float duration = 3f;
    float durationTimer;
    float exposionSize = 1.7f;

    float exposionRate = 0.12f;
    float exposionTimer;

    public override void OnAwake()
    {
        IsDamagable = false;
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
        if (durationTimer > duration)
        {
            var mikic = gameObject.GetComponent<MikicBossLogic>();
            mikic.OnDefeated?.Invoke();
            Destroy(mikic.gameObject);
        }
    }
}

