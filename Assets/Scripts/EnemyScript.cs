using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private WeaponScript[] weapons;

    // Start is called before the first frame update
    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var weapon in weapons)
        {
            weapon.Attack(true);
        }
    }
}
