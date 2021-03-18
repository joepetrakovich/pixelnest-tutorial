using UnityEngine;

public class EnemyVerticalMoveScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(0, 10);

    public Vector2 direction = new Vector2(0, 1);

    private Vector2 movement;
    private Rigidbody2D rigidBodyComponent;


    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        var transform = GetComponent<Transform>();

        //reverse movement speed when you hit screen edges
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.y < 0.0 && speed.y < 0) ReverseDirection();
        if (pos.y > 1.0 && speed.y > 0) ReverseDirection(); 

        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
    }

    private void ReverseDirection()
    {
        speed.y = -1 * speed.y;
    }

    void FixedUpdate()
    {
        if (rigidBodyComponent == null)
        {
            rigidBodyComponent = GetComponent<Rigidbody2D>();
        }

        rigidBodyComponent.velocity = movement;
    }
}
