using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuHandler : MonoBehaviour
{
    public Text finalScoreTxt;
    public static bool soundEnabled = true;
    public static bool musicEnabled = true;
    public Image soundBtnImg,musicBtnImg;

    public Sprite soundOnSprite, soundOffSprite;
    public Sprite musicOnSprite, musicOffSprite;


    void Start()
    {
      if (finalScoreTxt != null)  finalScoreTxt.text = PlayerPrefs.GetInt("score", 0).ToString();
        soundEnabled = PlayerPrefs.GetInt("sound", 0) == 0;
        soundEnabled = PlayerPrefs.GetInt("music", 0) == 0;

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
        if (musicEnabled)
        {
            musicEnabled = false;
            musicBtnImg.sprite = musicOffSprite;
        }
        else
        {
            musicEnabled = true;
            musicBtnImg.sprite = musicOnSprite;
        }

    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("Selection Scene");
    }

    public void ExitBtn()
    {
        Application.Quit();
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
    public void EnableDisableMusic()
    {
        if (musicEnabled)
        {
            musicEnabled = false;
            musicBtnImg.sprite = musicOffSprite;
            PlayerPrefs.SetInt("music", 0);
        }
        else
        {
            musicEnabled = true;
            musicBtnImg.sprite = musicOnSprite;
            PlayerPrefs.SetInt("music", 1);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

}
