using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class picture : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

            GetComponent<Button>().enabled = true;
    }
    public void LoadScene()
    {
        Debug.Log("Hi");
        GameManager.foldername = gameObject.name;
        SceneManager.LoadScene("SampleScene");
    }

}