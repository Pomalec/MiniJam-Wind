
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class inputcontrol : ScriptableObject
{
    public abstract float retrievmoveinput();
    public abstract float retrievmoveupinput();
    public abstract bool retrievejumpinput();
    public abstract bool retrievinteractinput();
}
