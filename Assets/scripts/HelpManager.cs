using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpManager : MonoBehaviour
{
    public Animator myAnim;

    public AudioClip[] myAudios;

    AudioSource audioSource;



    short indicator = -1;

    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    

    public void Surface()
    {
        indicator = 0;
        myAnim.Play("SurfaceBtn");
    }

    public void Speak()
    {
        indicator = 1;
        if (MainMenuHandler.soundEnabled) audioSource.PlayOneShot(myAudios[GameManager.level]);
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
