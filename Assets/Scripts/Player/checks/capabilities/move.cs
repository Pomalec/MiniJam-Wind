
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class move : MonoBehaviour
{
    public int edefeated = 0;
    public Animator animator;
    [SerializeField] private inputcontrol input=null;
    [SerializeField, Range(0f, 100f)] private float maxspeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxacceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxairacceleration = 20f;
    [SerializeField] LayerMask ladder;
    private Vector2 direction;
    private Vector2 desiredvelocity;
    private Vector2 velocity;
    private bool m_FacingRight = true;
    private Rigidbody2D body;
    private ground gr;
    BoxCollider2D boxCollider;
    private float maxspeedchange;
    private float acceleration;
    private bool onground;
    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        gr=GetComponent<ground>();
    }

    
    void Update()
    {
        direction.x = input.retrievmoveinput();
        if (direction.x > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (direction.x < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        animator.SetFloat("SPEED",Mathf.Abs (direction.x));
        desiredvelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxspeed - gr.getfriction(), 0f);
        if (input.retrievmoveupinput()>0&& isclimbing()) {
            animator.SetBool("climb", true);
           body.transform.position+=Vector3.up*acceleration * Time.deltaTime;
            //velocity.y = Mathf.MoveTowards(velocity.y, desiredvelocity.y, maxspeedchange);
        }
        if (isclimbing()) { body.gravityScale = 0; }
        if (!isclimbing()) { body.gravityScale = 1;
            animator.SetBool("climb", false);
        }
    }

    private void FixedUpdate()
    {
        onground = gr.getonground();
        velocity = body.velocity;

        acceleration=onground ? maxacceleration:maxairacceleration;
        maxspeedchange = acceleration* Time.deltaTime;
        velocity.x=Mathf.MoveTowards(velocity.x,desiredvelocity.x,maxspeedchange);

        body.velocity=velocity;


    }
    public bool isclimbing()
    {
        RaycastHit2D hitinnfo = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.01f, ladder);
        return hitinnfo.collider !=null;
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public int health = 100;
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
    public void adddefeat()
    {
        edefeated++;
    }
}
