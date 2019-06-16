using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuHandler : MonoBehaviour
{
    public Text finalScoreTxt;
    public static bool soundEnabled = true;
    public Image soundBtnImg;

    public Sprite soundOnSprite, soundOffSprite;

    void Start()
    {
        finalScoreTxt.text = PlayerPrefs.GetInt("score", 0).ToString();
        soundEnabled = PlayerPrefs.GetInt("sound", 0) == 0;
        if (soundEnabled)
        {
            soundEnabled = false;
            soundBtnImg.sprite = soundOffSprite;
        }
        else
        {
            soundEnabled = true;
            soundBtnImg.sprite = soundOnSprite;
        }
    }

    public void EnableDisableSound()
    {
        if (soundEnabled)
        {
            soundEnabled = false;
            soundBtnImg.sprite = soundOffSprite;
            PlayerPrefs.SetInt("sound", 0);
        }
        else
        {
            soundEnabled = true;
            soundBtnImg.sprite = soundOnSprite;
            PlayerPrefs.SetInt("sound", 1);
        }
    }
}
