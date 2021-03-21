using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSortingLayerScript : MonoBehaviour
{
    void Start()
    {
        // Set the sorting layer of the particle system.
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Bullets";
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 0;
    }
}
