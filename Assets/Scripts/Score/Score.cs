using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Scripts References")]
    [SerializeField] ChooseSize chooseSize;
    [SerializeField] SwitchPhase _switchPhase;
    [SerializeField] TimeLimit _timer;
    [SerializeField] PlaceObject _placeObject;
    [SerializeField] Guess _guess;

    [Header("Score")]
    [SerializeField] int maxScore = 1000;
    int hiderScore = 0;
    int seekerScore = 0;
    int objectScore = 0;
    int totalScore = 0;

    [Header("UI References")]
    public GameObject endCanvas;
    public TMP_Text hiderScoreText;
    public TMP_Text seekerScoreText;
    public TMP_Text TotalScore;
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
                objectScore += 1000;
                break;
            case 2:
                objectScore += 600;
                break;
            case 3:
                objectScore += 200;
                break;
            default:
                break;
        }
    }

    public void CalculateScore(bool TargetFound)
    {
        if (TargetFound)
        {
            //Sets the hider's score depending on the time it took to place the object
            switch (Mathf.RoundToInt(_placeObject.time))
            {
                case <= 30:
                    hiderScore += 200;
                    break;
                case > 30 and <= 60:
                    hiderScore += 150;
                    break;
                case > 60 and <= 90:
                    hiderScore += 100;
                    break;
                case > 90 and <= 120:
                    hiderScore += 50;
                    break;
                default:
                    break;
            }

            //Sets the seeker's score depending on the time it took to find the object
            int GuessesThrown = _switchPhase._guessScript.maxGuess - _switchPhase._guessScript.remainingGuess - 1;
            int GuessThrownScore = GuessesThrown * 150;
            int scoreLost = 2 * (_timer.initialTime - Mathf.RoundToInt(_timer.time));
            //cap the lost score to the max score so the seeker can't have a negative score
            if (scoreLost > maxScore)
            {
                scoreLost = maxScore;
            }
            seekerScore = maxScore - scoreLost + GuessThrownScore;

            //Add the object score if it is find before the half of the time
            if (_timer.time > _timer.initialTime / 2)
            {
                hiderScore += objectScore;
            }

            //Sets the total score
            totalScore = hiderScore + seekerScore;
        }
        else
        {
            totalScore = 0;
            hiderScore = 0;
            seekerScore = 0;
        }
        displayEnd(TargetFound);
    }
    void displayEnd(bool targetfound)
    {
        endCanvas.SetActive(true);

        hiderScoreText.text = $"Hider Score : {hiderScore}";
        seekerScoreText.text = $"Seeker Score : {seekerScore}";
        TotalScore.text = $"Total Score : {totalScore}";
        if (targetfound)
        {
            FinalText.text = "Welldone, deal carried out";
        }
        else
        {
            FinalText.text = "Shame on you, bad dealer";
        }
    }
}
