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
        //PlayerPrefs.DeleteAll();
        if (levelToUnlock <= PlayerPrefs.GetInt("saveData", 0))
        {
            LockBtn.gameObject.SetActive(false);
        }
        else
            GetComponent<Button>().enabled = false;
    }
    public void LoadScene()
    {
        GameManager.foldername = gameObject.name;
        GameManager.level = levelToUnlock;
        SceneManager.LoadScene("SampleScene");
    }

}