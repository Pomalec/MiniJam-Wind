<<<<<<< HEAD
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveobject : MonoBehaviour
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
        if (input.retrievinteractinput())
        {
            desiredvelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxspeed, 0f);
        }
    }

 
    private void FixedUpdate()
    {
        if (input.retrievinteractinput())
        {
            onground = gr.getonground();
            velocity = body.velocity;

            acceleration = onground ? maxacceleration : maxairacceleration;
            maxspeedchange = acceleration * Time.deltaTime;
            velocity.x = Mathf.MoveTowards(velocity.x, desiredvelocity.x, maxspeedchange);
=======
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveobject : MonoBehaviour
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
        if (input.retrievinteractinput())
        {
            desiredvelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxspeed, 0f);
        }
    }

 
    private void FixedUpdate()
    {
        if (input.retrievinteractinput())
        {
            onground = gr.getonground();
            velocity = body.velocity;

            acceleration = onground ? maxacceleration : maxairacceleration;
            maxspeedchange = acceleration * Time.deltaTime;
            velocity.x = Mathf.MoveTowards(velocity.x, desiredvelocity.x, maxspeedchange);
>>>>>>> 26e1d48ef9d4a2f9e5bcc936e768a2cfb934aed7
        
            body.velocity = velocity;
        }
        else
        {
            body.velocity = Vector2.zero;
        }




<<<<<<< HEAD



    }
}
=======



    }
}
>>>>>>> 26e1d48ef9d4a2f9e5bcc936e768a2cfb934aed7
