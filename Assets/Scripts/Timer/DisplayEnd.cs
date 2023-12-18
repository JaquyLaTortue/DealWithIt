using TMPro;
using UnityEngine;

public class DisplayEnd : MonoBehaviour
{
    [SerializeField] SwitchPhase _switchPhaseScript;

    [SerializeField] GameObject endCanvas;
    [SerializeField] TMP_Text finalText;

    private void Start()
    {
        _switchPhaseScript.OnGameEnded += DisplayEndScreen;
    }

    void DisplayEndScreen(bool TargetFound)
    {
        endCanvas.SetActive(true);
        if (TargetFound )
        {
            finalText.text = "Seeker Win, what sense of observation";
        }
        else
        {
            finalText.text = "Hider Win, nice hiding place";
        }
    }

}
