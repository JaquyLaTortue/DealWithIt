using TMPro;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public float temps = 10;
    public TMP_Text timertext;
    public int tempsint;

    public GameObject EndOfTime;
    
   

    void Start()
    {
        EndOfTime.SetActive(false);
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
        else if (temps <= 0 && !EndOfTime.activeSelf) 
        {
            Appear();
        }
        
        
    }

    void Appear()
    {
        EndOfTime.SetActive(true);
    }
    
}
