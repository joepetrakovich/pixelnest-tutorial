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
            }
        }
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

}
