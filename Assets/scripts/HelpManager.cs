using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpManager : MonoBehaviour
{
    public Animator myAnim;

    public AudioClip[] myAudios;
    public GameObject exitBtn,hideHelpPanelBtn;
    public GameObject[] helpButtons;

    public string[] capitalInfos, languageInfos, surfaceInfos;

    AudioSource audioSource;

    public Text infoTxt;

    short indicator = -1;

    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    

    public void Surface()
    {
        exitBtn.SetActive(true);
        indicator = 0;
        myAnim.Play("SurfaceBtn");
        if (GameManager.level < languageInfos.Length)
        infoTxt.text = surfaceInfos[GameManager.level];
    }

    public void ShowHelpPanel()
    {
        hideHelpPanelBtn.SetActive(true);
        myAnim.Play("ShowHelpPanel");
    }

    public void HideHelpPanel()
    {
        hideHelpPanelBtn.SetActive(false);
        myAnim.Play("HideHelpPanel");
    }

    public void Speak()
    {
        if (MainMenuHandler.soundEnabled) audioSource.PlayOneShot(myAudios[GameManager.level]);
    }


    public void CapitalBtn()
    {
        exitBtn.SetActive(true);
        indicator = 1;
        if (GameManager.level < languageInfos.Length)
        infoTxt.text = capitalInfos[GameManager.level];
        myAnim.Play("Speak");
    }

    public void LangBtn()
    {
        exitBtn.SetActive(true);
        indicator = 2;
        if (GameManager.level < languageInfos.Length)
        infoTxt.text = languageInfos[GameManager.level];
        myAnim.Play("Lang");
    }

    public void ExitBtn()
    {
        switch (indicator)
        {
            case 0: myAnim.Play("SurfaceClose"); helpButtons[0].SetActive(true); break;
            case 1: myAnim.Play("SpeakClose"); helpButtons[1].SetActive(true); break;
            case 2: myAnim.Play("LangClose"); helpButtons[2].SetActive(true); break;
            default: Debug.Log("ERR"); break;
        }
        indicator = -1;
        exitBtn.SetActive(false);

    }

}
