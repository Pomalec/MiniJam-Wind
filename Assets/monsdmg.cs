<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsdmg : MonoBehaviour
{
    public int dmg;
    public playerhealth ph;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ph.takedmg(dmg);
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsdmg : MonoBehaviour
{
    public int dmg;
    public playerhealth ph;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ph.takedmg(dmg);
        }
    }
}
>>>>>>> 26e1d48ef9d4a2f9e5bcc936e768a2cfb934aed7
