
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private ParticleSystem _effect;
    ParticleSystem.MainModule explosionMainModule;

    public static Particle instance;

    private void Awake()
    {
        instance = this;
      
    }

    private void Start()
    {
       explosionMainModule = _effect.main;
      
    }

    public void PlayExplosion(Vector3 position, Color color)
    {

        explosionMainModule.startColor = new ParticleSystem.MinMaxGradient (color);
        _explosion.transform.position = position;
        _effect.transform.position = position;
        _explosion.Play();
        _effect.Play();
    }
}
