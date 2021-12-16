using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLogic : MonoBehaviour
{
    SpriteRenderer particleRenderer;

    float currentMs = 0;
    float startAlpha = 0.8f;
    float introMs = 0.5f;
    float fadeoutMs = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        particleRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float opacity;
        if(currentMs <= introMs)
        {
            opacity = GameHelper.MapValue(currentMs, 0, introMs, startAlpha, 1);
        }
        else
        {
            opacity = GameHelper.MapValue(currentMs, introMs, introMs+fadeoutMs, 1, 0);
        }

        particleRenderer.color = new Color(1, 1, 1, opacity);

        currentMs += Time.deltaTime;
        if (currentMs > introMs + fadeoutMs) Destroy(gameObject);
    }
}
