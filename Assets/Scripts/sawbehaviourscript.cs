using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawbehaviourscript : MonoBehaviour
{
    public float speedx;
    public float speedy;
    [SerializeField]private Rigidbody2D rb;
    // Start is called before the first frame update

    void Start()
    {
        speedx = 1;
    }
    void Update()
    {
        moving();
    }

    // Update is called once per frame
   

    private void moving()
    {
        
       if(speedx == 0){
         rb.velocity = new Vector2(0,rb.velocity.y + speedy);
        }
        else if(speedy == 0){
         rb.velocity = new Vector2(rb.velocity.x + speedx, 0);
        }
        else{
        rb.velocity = new Vector2(rb.velocity.x + speedx, rb.velocity.y + speedy);
        }
        
        
    }

    
}
