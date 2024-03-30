using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundeffectplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;
    public  void btn1()
    {
        src.clip = sfx1;
        src.Play();
    } public  void btn2()
    {
        src.clip= sfx2;
        src.Play();
    } public  void btn3()
    {
        src.clip = sfx3;
        src.Play();
    }
}
