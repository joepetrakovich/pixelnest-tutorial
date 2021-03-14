using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform shotPrefab;

    public float shootingRate = 0.25f;

    private float shootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public bool CanAttack => shootCooldown <= 0f;

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;
            shotTransform.rotation = transform.rotation;

            var shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
                
            }

            var move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right;
            }
        }
    }
}
