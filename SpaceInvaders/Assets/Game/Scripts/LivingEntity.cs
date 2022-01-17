using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    public event Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    protected void Die()
    {
        dead = true;
        OnDeath?.Invoke();
        if (gameObject.GetComponent<Enemy>())
        {
            GameObject.Destroy(gameObject);
        }
    }
}

