<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{

    public float targetTime;
    bool ended=false;
    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    public void timerEnded()
    {
        ended = true;
        //do your stuff here.
    }
    public void timerstart() {
    targetTime = 60.0f;
}
    public bool getended() { targetTime = 60.0f;  ended=false; return ended; }

}

=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{

    public float targetTime;
    bool ended=false;
    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    public void timerEnded()
    {
        ended = true;
        //do your stuff here.
    }
    public void timerstart() {
    targetTime = 60.0f;
}
    public bool getended() { targetTime = 60.0f;  ended=false; return ended; }

}

>>>>>>> 26e1d48ef9d4a2f9e5bcc936e768a2cfb934aed7
