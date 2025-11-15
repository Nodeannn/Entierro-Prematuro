using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Luces : MonoBehaviour
{
    public Light2D light2D;

    [Header("Intensidad base")]
    public float baseIntensity = 0.7f;

    [Header("Variación de intensidad")]
    [Range(0f, 0.3f)]
    public float intensityVariation = 0.1f;

    [Header("Color")]
    public Color baseColor = Color.white;
    [Range(0f, 0.02f)]
    public float colorVariation = 0.01f;

    [Header("Velocidad")]
    [Range(0.05f, 1f)]
    public float speed = 0.15f;

    float t;

    void Start()
    {
        if (light2D == null)
            light2D = GetComponent<Light2D>();

        t = Random.Range(0f, 1000f);
    }

    void Update()
    {
        t += Time.deltaTime * speed;

       
        float noise = Mathf.PerlinNoise(t, t * 0.4f);

    
        float newIntensity = baseIntensity + (noise - 0.5f) * intensityVariation * 2f;
        light2D.intensity = newIntensity;


        Color c = light2D.color;
        c.r = baseColor.r + (noise - 0.5f) * colorVariation;
        c.g = baseColor.g + (noise - 0.5f) * colorVariation;
        c.b = baseColor.b;
        light2D.color = c;
    }
}
