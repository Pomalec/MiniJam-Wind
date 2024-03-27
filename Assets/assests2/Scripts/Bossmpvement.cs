using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmpvement : MonoBehaviour
{
    public Animator animator;
    private float horizontal;
    private bool isFacingRight = true;
    [SerializeField]private float speed;
    //[SerializeField]private float jump;
    [SerializeField]private Rigidbody2D rb;
   
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        mirrorflip();
        bossmoving();
    }

    private void bossmoving()
    {
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
    }

    private void mirrorflip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Trigger");
    }
}
