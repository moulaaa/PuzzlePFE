using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class picture : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Test");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        GameManager.foldername = gameObject.name;
        SceneManager.LoadScene("SampleScene");
    }

}