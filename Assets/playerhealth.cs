
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxhealth = 10;
    public int health;
    void Start()
    {
        health = maxhealth;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takedmg(int dmg)
    {
        health-= dmg;
        if (health < 0) { Destroy(gameObject); }
    }
}
