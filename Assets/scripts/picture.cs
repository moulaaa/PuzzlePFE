using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class picture : MonoBehaviour
{

    public Image LockBtn;
    public int levelToUnlock;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 100; i++)
        {
            if (PlayerPrefs.HasKey(levelToUnlock.ToString()))
            {
                LockBtn.enabled = true;
            }
        }
    }
    public void LoadScene()
    {
        GameManager.foldername = gameObject.name;
        GameManager.level = levelToUnlock;
        SceneManager.LoadScene("SampleScene");
    }

}