using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawmove3 : MonoBehaviour
{
    
    public sawbehaviourscript script;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        script.speedx = 0;
        script.speedy = 1;
        
        
    }
}
