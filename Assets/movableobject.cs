using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movableobject : MonoBehaviour
{
    [SerializeField] private inputcontrol input = null;
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
    bool playercol = false;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        gr = GetComponent<ground>();
    }
    // Update is called once per frame
    void Update()
    {

        direction.x = input.retrievmoveinput();
        if (input.retrievinteractinput()&&playercol)
        {
            desiredvelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxspeed, 0f);
        }
    }


    private void FixedUpdate()
    {
        if (input.retrievinteractinput()&&playercol)
        {
            onground = gr.getonground();
            velocity = body.velocity;

            acceleration = onground ? maxacceleration : maxairacceleration;
            maxspeedchange = acceleration * Time.deltaTime;
            velocity.x = Mathf.MoveTowards(velocity.x, desiredvelocity.x, maxspeedchange);

            body.velocity = velocity;
        }
        else
        {
            body.velocity = Vector2.zero;
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playercol = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playercol = false;
        }
    }
}
