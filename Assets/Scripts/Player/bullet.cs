
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Animator animator;
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    float initalpos;

    // Start is called before the first frame update
    
    void Start()
    {
        rb.velocity = transform.right * speed;
        initalpos = rb.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x > initalpos+20)
        {
            animator.SetBool("isfiring", false);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enemy e = hitInfo.GetComponent<enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
