using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class windmagic : MonoBehaviour
{
    bool sel;
    [SerializeField] private inputcontrol input = null;
    public UnityEvent selected;
    public UnityEvent deselected;
    // Start is called before the first frame update
    void Start()
    {
        sel = false;
    }
    public void addselected()
    {
       
            sel = true;
           
        
      

    }
    public void removeselected()
    {
        sel = false; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
