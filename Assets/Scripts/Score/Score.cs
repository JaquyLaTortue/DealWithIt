using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Scripts References")]
    [SerializeField] ChooseSize chooseSize;
    [SerializeField] SwitchPhase _switchPhase;
    [SerializeField] TimeLimit _timer;

    [Header("Score")]
    [SerializeField] int maxScore = 1000;
    int hiderScore;
    int seekerScore = 0;
    int objectScore = 0;

    [Header("UI References")]
    public GameObject endCanvas;
    public TMP_Text hiderScoreText;
    public TMP_Text seekerScoreText;
    public TMP_Text FinalText;

    [Header("Bools")]
    public bool StartGuessing = false;

    private void Start()
    {
        _switchPhase.OnGameEnded += CalculateScore;

        chooseSize.OnSizeChoosed += SetObjectSize;
    }

    void SetObjectSize(int size)
    {
        switch (size)
        {
            case 1:
                objectScore += 200;
                break;
            case 2:
                objectScore += 600;
                break;
            case 3:
                objectScore += 1000;
                break;
            default:
                break;
        }
    }

    public void CalculateScore(bool TargetFound)
    {
        endCanvas.SetActive(true);
        if (TargetFound)
        {
            int GuessesThrown = _switchPhase._guessScript.maxGuess - _switchPhase._guessScript.remainingGuess - 1;
            int GuessThrownScore = GuessesThrown * 150;
            int scoreLost = 2 * (_timer.initialTime - Mathf.RoundToInt(_timer.time));
            if (scoreLost > maxScore) { scoreLost = maxScore; }
            seekerScore = maxScore - scoreLost + GuessThrownScore;
            hiderScore = scoreLost + GuessThrownScore;

            if (_timer.time > _timer.initialTime / 2)
            {
                seekerScore += objectScore;
                if (seekerScore < 0) seekerScore = 0;
            }
            else
            {
                hiderScore += objectScore;
            }
            hiderScoreText.text = hiderScore.ToString();
            seekerScoreText.text = seekerScore.ToString();
            Debug.Log($"HiderScore : {hiderScore} / SeekerScore : {seekerScore}");
        }
        else
        {
            hiderScore = maxScore + objectScore;
            hiderScoreText.text = hiderScore.ToString();

            seekerScore = 0;
            seekerScoreText.text = seekerScore.ToString();
        }

        if (hiderScore > seekerScore)
        {
            FinalText.text = "Hider Win, nice hiding place";
        }
        else
        {
            FinalText.text = "Seeker Win, what sense of observation";
        }
    }
}
