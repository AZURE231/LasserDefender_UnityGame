using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer)
        {
            // Take damage.
            damageDealer.Hit();
            TakeDamage(damageDealer.GetDamage());
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        // destroy when run out of health.
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
