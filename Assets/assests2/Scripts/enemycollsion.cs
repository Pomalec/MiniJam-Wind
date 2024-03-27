using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycollsion : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
    }
}
