using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuHandler : MonoBehaviour
{
    public Text finalScoreTxt;


    void Start()
    {
        finalScoreTxt.text = PlayerPrefs.GetInt("score", 0).ToString();
    }
}
