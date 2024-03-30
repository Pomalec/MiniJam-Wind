using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchplat : MonoBehaviour
{
    // Start is called before the first frame update
    bool playercol;
    void Start()
    {
        playercol = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("boulder"))
        {
            playercol = true;
        }
        else
        {
            playercol = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
