using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Numerics;
using UnityEngine.AI;
using UnityEditor.PackageManager;

public class EnemyAi : MonoBehaviour
{

    public Animator animator;
    public Transform target;
    public int damage = 40;
    public float movingspeed = 0;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public bool hunt = false;

    public Transform enemyfacing;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
        InvokeRepeating("UpdatePath", 0f, .5f);
        movingspeed = movingspeed + 1;
        animator.SetFloat("speed", movingspeed);
       
       
        
    }



    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            hunt = true;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }
            

        if(currentWaypoint >=path.vectorPath.Count)
        {
            
            reachedEndofPath = true;
            return;
            
        } 
        else
        {   
            reachedEndofPath = false;
        }

        UnityEngine.Vector2 direction = ((UnityEngine.Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        UnityEngine.Vector2 force = direction * speed * Time.deltaTime;

        if (hunt == true)
        {
            rb.AddForce(force);
           
            
        }

        

        float distance = UnityEngine.Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(force.x >= 0.01f)
        {
            enemyfacing.localScale = new UnityEngine.Vector3(-4f, 4f, 4f);
        }
        else if(force.x <= -0.01f)
        {
            enemyfacing.localScale = new UnityEngine.Vector3(4f, 4f, 4f);
        }
        
    }

    public int health = 100;

    public GameObject deathEffect;
    public GameObject impactEffect;
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
        Instantiate(deathEffect, transform.position, UnityEngine.Quaternion.identity);
        Destroy(gameObject);
    }
    void playerdmg(Collider2D hitInfo) {
        move p = hitInfo.GetComponent<move>();
        if (p != null)
        {
            p.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        
       
    }
}
