using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
   [SerializeField] private inputcontrol input = null;
   

     private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (input.retrievinteractinput() && collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 3);
            
        }
        
    }
}
