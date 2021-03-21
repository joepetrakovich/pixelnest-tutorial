using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int hp = 1;

    public bool isEnemy = true;

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            SoundEffectsHelper.Instance.MakeExplosionSound();
            Destroy(gameObject);
        }
    }

    private bool IsHitByOpponentShot(Collider2D collider, out ShotScript shot)
    {
        shot = collider.gameObject.GetComponent<ShotScript>();

        return shot != null && 
            ((shot.isEnemyShot && !this.isEnemy) || 
            (!shot.isEnemyShot && this.isEnemy));
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (IsHitByOpponentShot(otherCollider, out ShotScript shot))
        {
            Damage(shot.damage);
            Destroy(shot.gameObject);
        }
    }
}
