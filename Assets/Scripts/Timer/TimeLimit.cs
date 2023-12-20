using System;
using TMPro;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    [Header("Time Limit in seconds")]
    //Time limit in seconds
    public int initialTime = 300;
    public float time=0;
    int tempsint;

    [Header("References")]
    [SerializeField] TMP_Text timertext;
    [SerializeField] GameObject FinishedUI;
    [SerializeField] SwitchPhase _switchPhase;

    [Header("Bools")]
    bool isFinished = false;
    bool started = false;

    public event Action<bool> OnTimerEnded;

    private void Start()
    {
        _switchPhase.OnGuessStart += StartTimer;
        _switchPhase.OnGameEnded += StopTimer;
        time = initialTime;
    }
    void Update()
    {
        if (!isFinished && started)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                //tempsint = Mathf.RoundToInt(time);

                float min = Mathf.FloorToInt(time / 60);
                float sec = Mathf.FloorToInt(time % 60);
                if (sec < 10)
                {
                    timertext.text = ($"0{min} : 0{sec}");
                    return;
                }
                else
                {
                    timertext.text = ($"0{min} : {sec}");
                }
            }
            else if (time <= 0)
            {
                timertext.text = "00 : 00";
                isFinished = true;
                FinishedUI.SetActive(true);
                OnTimerEnded?.Invoke(false);
            }
        }
    }

    void StartTimer()
    {
        started = true;
    }

    void StopTimer(bool uselessBool)
    {
        isFinished = true;
    }
}
