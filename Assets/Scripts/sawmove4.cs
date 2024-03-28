using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawmove4 : MonoBehaviour
{
    
    public sawbehaviourscript script;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        script.speedx = 1;
        script.speedy = 0;
        
        
    }
}
