
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
    public override bool retrievewindability()
    {
        return Input.GetButton("Fire4");
    }

}



