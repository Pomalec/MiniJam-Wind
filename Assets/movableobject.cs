using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class movableobject : MonoBehaviour
{
    [SerializeField] private inputcontrol input = null;
    [SerializeField, Range(0f, 100f)] private float maxspeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxacceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxairacceleration = 20f;
    [SerializeField] GameObject pl;
    [SerializeField] LayerMask ladder;
    private Vector2 direction;
    private Vector2 desiredvelocity;
    private Vector2 velocity;
    private bool m_FacingRight = true;
    public UnityEvent selected;
    public UnityEvent deselected;
    private Rigidbody2D body;
    private ground gr;
    BoxCollider2D boxCollider;
    private float maxspeedchange;
    private float acceleration;
    private bool onground;
    bool playercol = false;
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = Color.blue;
    }
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        gr = GetComponent<ground>();
    }
    // Update is called once per frame
    void Update()
    {
        onground = gr.getonground();
        if (onground)
        {
            body.gravityScale = 1f;
        }
        else
        {
            body.gravityScale = 9.1f;
        }
        m_NewColor = new Color(0, 100, 0);
        direction.x = input.retrievmoveinput();
        if (input.retrievinteractinput() && playercol)
        {
            desiredvelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxspeed, 0f);
        }
    }


    private void FixedUpdate()
    {

        if (input.retrievinteractinput() && playercol)
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
    public void setplayercol()
    {

        playercol = true;


    }
    public void setplayercolf()
    {

        playercol = false;
    }
    void OnMouseDown()
    {

        if (playercol)
        {
            playercol = false;
            m_NewColor = new Color(0, 0, 100);

            //Set the SpriteRenderer to the Color defined by the Sliders

        }
        else
        {
            playercol = true;
            //Set the Color to the values gained from the Sliders
            m_NewColor = new Color(0, 0, 0);

            //Set the SpriteRenderer to the Color defined by the Sliders

        }
        m_SpriteRenderer.color = m_NewColor;




    }
}