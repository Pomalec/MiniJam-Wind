<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="playercontroller",menuName="inputcontrol/playercontroller")]
public class playercontroller : inputcontrol
{
    public override bool retrievejumpinput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float retrievmoveinput()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public override float retrievmoveupinput()
    {
        return Input.GetAxisRaw("Vertical");
    }
    public override bool retrievinteractinput()
    {
        return Input.GetButton("Fire2");
    }
    
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="playercontroller",menuName="inputcontrol/playercontroller")]
public class playercontroller : inputcontrol
{
    public override bool retrievejumpinput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float retrievmoveinput()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public override float retrievmoveupinput()
    {
        return Input.GetAxisRaw("Vertical");
    }

}
>>>>>>> 26e1d48ef9d4a2f9e5bcc936e768a2cfb934aed7
