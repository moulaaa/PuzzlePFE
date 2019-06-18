using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    public Animator myAnim;

    short indicator = -1;
    public void Surface()
    {
        indicator = 0;
        myAnim.Play("SurfaceBtn");
    }

    public void Speak()
    {
        indicator = 1;
        myAnim.Play("Speak");
    }

    public void ExitBtn()
    {
        switch (indicator)
        {
            case 0: myAnim.Play("SurfaceClose"); break;
            case 1: myAnim.Play("SpeakClose"); break;
            default: Debug.Log("ERR"); break;
        }
        indicator = -1;
    }

}
