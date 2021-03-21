using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectsHelper : MonoBehaviour
{
    public static SpecialEffectsHelper Instance;

    public ParticleSystem smokeEffect;
    public ParticleSystem fireEffect;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    /// <summary>
    /// Create an explosion at the given location.
    /// </summary>
    /// <param name="position"></param>
    public void Explosion(Vector3 position)
    {
        instantiate(smokeEffect, position);

        instantiate(fireEffect, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        var newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;

        Destroy(newParticleSystem.gameObject, newParticleSystem.main.startLifetime.constant);

        return newParticleSystem;
    }
}
