using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] ChooseSize chooseSize;
    [SerializeField] SwitchPhase _switchPhase;

    int hiderScore;
    int seekerScore;

    int objectScore;
    [SerializeField] int maxScore = 1000;


    public TMP_Text hiderScoreText;
    public TMP_Text seekerScoreText;

    float elapsedTime;

    public bool StartGuessing = false;
    public bool finised = false;

    private void Start()
    {
        _switchPhase.OnGameEnded += CalculateScore;

        seekerScore = maxScore;
        hiderScore = 0;

        elapsedTime = 0;

        chooseSize.OnSizeChoosed += SetObjectSize;
    }

    private void FixedUpdate()
    {
        if (StartGuessing && !finised)
        {
            elapsedTime += Time.deltaTime;
        }
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
        if (TargetFound)
        {
            int GuessesThrown = _switchPhase._guessScript.maxGuess - _switchPhase._guessScript.remainingGuess;
            int GuessThrownScore = GuessesThrown * 150;
            Debug.Log($"GuessesThrown : {GuessesThrown} / GuessThrownScore : {GuessThrownScore}");
            int scoreLost = (Mathf.RoundToInt(elapsedTime) * 2);
            seekerScore = seekerScore - (scoreLost + GuessThrownScore);
            hiderScore += scoreLost + GuessThrownScore;

            finised = false;
            if (elapsedTime < 120)
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
            hiderScore = maxScore;
            hiderScoreText.text = hiderScore.ToString();

            seekerScore = 0;
            seekerScoreText.text = seekerScore.ToString();
        }
    }
}
