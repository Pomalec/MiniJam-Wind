using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawmove2 : MonoBehaviour
{
    // Start is called before the first frame update
    public sawbehaviourscript script;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        script.speedx = -1;
        script.speedy = 0;
        
        
    }
}
