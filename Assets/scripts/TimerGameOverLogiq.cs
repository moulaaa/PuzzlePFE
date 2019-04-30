using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGameOverLogiq : MonoBehaviour
{
    int CountDownStartValue =5 ; 
    // Start is called before the first frame update
    void Start()
    {
        CountDownTimer();
    }
    void CountDownTimer()
    {
        if (CountDownStartValue > 0)
        {
            Debug.Log("Timer:" + CountDownStartValue);
            CountDownStartValue--;
            Invoke("CountDownStartValue", 1.0f);
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
