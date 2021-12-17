using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParticleFactory
{
    public static GameObject Create(ParticleType type, Vector2 position)
    {
        GameObject particle;
        switch (type)
        {
            case ParticleType.Explosion:
                particle = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Particles/ExplosionParticle"));
                break;
            default:
                throw new NotImplementedException($"Pattern Factory for type '{type}' is not implemented");
        }

        particle.transform.position = position;
        return particle;
    }
}

public enum ParticleType
{
    Explosion
}