using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //making this public will allow Unity to provide a UI to change it.
    public Vector2 speed = new Vector2(50, 50);

    private Vector2 movement;
    private Rigidbody2D rigidBodyComponent;


    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(
            speed.x * inputX,
            speed.y * inputY);

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            var weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
                SoundEffectsHelper.Instance.MakePlayerShotSound();
            }
        }

        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
    }

    void FixedUpdate()
    {
        if (rigidBodyComponent == null)
        {
            rigidBodyComponent = GetComponent<Rigidbody2D>();
        }

        //all we have to do is assign the velocity to the body
        //and it will move.

        rigidBodyComponent.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var enemyScript = collision.gameObject.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            var enemyHealth = enemyScript.GetComponent<HealthScript>();
            enemyHealth.Damage(enemyHealth.hp);
        }

        var playerHealth = GetComponent<HealthScript>();
        playerHealth.Damage(1);
    }

}
