using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool isSpawned;
    private EnemyVerticalMoveScript moveScript;
    private WeaponScript[] weapons;
    private Collider2D colliderComponent;
    private SpriteRenderer rendererComponent;

    // Start is called before the first frame update
    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();
        moveScript = GetComponent<EnemyVerticalMoveScript>();
        colliderComponent = GetComponent<Collider2D>();
        rendererComponent = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        isSpawned = false;
        colliderComponent.enabled = false;
        moveScript.enabled = false;
        foreach (var weapon in weapons) weapon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawned)
        {
            if (rendererComponent.IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            foreach (var weapon in weapons)
            {
                weapon.Attack(true);
                //SoundEffectsHelper.Instance.MakeEnemyShotSound();
            }

            if (!rendererComponent.IsVisibleFrom(Camera.main))
            {
                Destroy(gameObject);
            }
        }
    }

    private void Spawn()
    {
        isSpawned = true;
        colliderComponent.enabled = true;
        moveScript.enabled = true;
        foreach (var weapon in weapons) weapon.enabled = true;
    }
}
