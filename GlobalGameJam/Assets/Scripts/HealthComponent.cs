using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] float startingHealth=100f;

    float health;
    bool dead = false;

    private void Awake()
    {
        health = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (!dead && health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
