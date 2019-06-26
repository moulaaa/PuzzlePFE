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

    public static bool canPlay = false;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canPlay = false;
      if (finalScoreTxt != null)  finalScoreTxt.text = PlayerPrefs.GetInt("score", 0).ToString();
        soundEnabled = PlayerPrefs.GetInt("sound", 0) == 1;
        musicEnabled = PlayerPrefs.GetInt("music", 0) == 1;

        if (soundEnabled) soundBtnImg.sprite = soundOnSprite; else soundBtnImg.sprite = soundOffSprite;
        if (musicEnabled) musicBtnImg.sprite = musicOnSprite; else musicBtnImg.sprite = musicOffSprite;

        if (musicEnabled && !(SceneManager.GetActiveScene().name == "SampleScene"))
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }

    }

    private void Update()
    { 
            if ((SceneManager.GetActiveScene().name == "MainMenu" ||canPlay) && musicEnabled) audioSource.enabled = true;
            else audioSource.enabled = false;

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
            audioSource.enabled = false;
            musicBtnImg.sprite = musicOffSprite;
            PlayerPrefs.SetInt("music", 0);
        }
        else
        {
            musicEnabled = true;
            audioSource.enabled = true;
            musicBtnImg.sprite = musicOnSprite;
            PlayerPrefs.SetInt("music", 1);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

}
