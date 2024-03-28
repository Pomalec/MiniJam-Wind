using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class enemy : MonoBehaviour
{
    public int health = 100;
    public Animator animator;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        animator.SetBool("alive", false);
    }
    
}


