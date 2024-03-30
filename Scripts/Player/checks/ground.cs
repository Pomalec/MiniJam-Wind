
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    private bool onground;
    private float friction;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        evaluatecollision(collision);
        retrievefriction(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        evaluatecollision(collision);
        retrievefriction(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onground = false;
        friction = 0;
    }
    private void evaluatecollision(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            onground |= normal.y > 0.9f;
        }
    }
    private void retrievefriction(Collision2D collision)
    {
        PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;
        friction = 0;
        if (material != null)
        {
            friction = material.friction;
        }
    }
    public bool getonground() {  return onground; }
    public float getfriction() { return friction; }
}

   
