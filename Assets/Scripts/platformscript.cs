using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformscript : MonoBehaviour
{

    
    private float speedy;
    [SerializeField]private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        speedy = -0.15f;
    }

    void Update()
    {
        moving();
    }
    

    private void moving()
    {
       rb.velocity = new Vector2(0,rb.velocity.y + speedy);
    }

    


     private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.CompareTag("check1"))
        {
            rb.velocity = new Vector2(0,0);
            speedy = 0.15f;
            
        }
        else if(collider.gameObject.CompareTag("check2")){
            rb.velocity = new Vector2(0,0);
            speedy = -0.15f;
        }
        
    }
}
