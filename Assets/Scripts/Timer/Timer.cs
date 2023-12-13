using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float temps = 10;
    public TMP_Text timertext;
    public int tempsint;
    
   

    void Start()
    {
        
    }

    void Update()
    {
        tempsint = Mathf.RoundToInt(temps);
        if (temps >= 0)
        {
            temps -= Time.deltaTime;
            float min = Mathf.FloorToInt(temps / 60);
            float sec = Mathf.FloorToInt(temps % 60);
            if (sec < 10)
            {
                timertext.text = ($"0{min} : 0{sec}");
                return;
            }
            timertext.text = ($"0{min} : {sec}");

        }
    }

    
}
