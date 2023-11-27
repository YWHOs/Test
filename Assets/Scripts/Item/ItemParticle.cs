using UnityEngine;

public class ItemParticle : MonoBehaviour
{
    ParticleSystem particle;

    [SerializeField] float particleSpeed;
    [SerializeField] Color color;
    [SerializeField] float xScale = 1;
    [SerializeField] float yScale = 1;
    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }
    void Start()
    {
        SetParticleSpeed();
        SetParticleColor();
        SetParticleScale();
        particle.Play();
    }
    void SetParticleSpeed()
    {
        ParticleSystem.MainModule particleModule = particle.main;
        particleModule.simulationSpeed = particleSpeed;
    }
    void SetParticleColor()
    {
        ParticleSystem.MainModule particleModule = particle.main;
        particleModule.startColor = new Color(color.r, color.g, color.b);
    }
    void SetParticleScale()
    {
        particle.transform.localScale = new Vector2(xScale, yScale);
    }
}
