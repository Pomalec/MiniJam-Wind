
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private inputcontrol input=null;
    [SerializeField, Range(0f, 10f)] private float jumpheight = 3f;
    [SerializeField, Range(0, 5)] private float maxairjumps = 0;
    [SerializeField, Range(0f, 5f)] private float downwardmovemulti = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardmovemulti = 1.7f;

    private Rigidbody2D body;
    private ground gr;
    private Vector2 velocity;

    private int jumphase;
    private float defaultgravityscale;

    private bool desiredjump;
    private bool onground;
    // Start is called before the first frame update
    void Awake()
    {
        body=GetComponent<Rigidbody2D>();
        gr=GetComponent<ground>();

        defaultgravityscale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        desiredjump |= input.retrievejumpinput();
        

    }
    private void FixedUpdate()
    {
        onground=gr.getonground();
        
        animator.SetBool("isjumping", !gr.getonground());
        velocity =body.velocity;
        if (onground)
        {
            jumphase = 0;
            //animator.SetBool("isjumping", false);
        }
        if (desiredjump) { desiredjump = false; jumpaction(); }
        if (body.velocity.y > 0) { body.gravityScale=upwardmovemulti; }
        else if (body.velocity.y<0)
        {
            body.gravityScale = downwardmovemulti;
        }
        else if (body.velocity.y == 0) { body.gravityScale=defaultgravityscale;  }
        body.velocity = velocity;
    }
    private void jumpaction() {
        if (onground||jumphase<maxairjumps)
        {
            
            jumphase += 1;
            float jumpspeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpheight);
            if (velocity.y>0f)
            {
                jumpspeed = Mathf.Max(jumpspeed - velocity.y, 0f);

            }
            velocity.y += jumpspeed;
        }
    }

}
