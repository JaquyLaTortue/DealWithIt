using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchPhase : MonoBehaviour
{
    [Header("Scripts References")]
    [SerializeField] Guess _guessScript;
    [SerializeField] PlaceObject _placeObjectScript;
    [SerializeField] CursorManager _cursorManager;
    [SerializeField] Score _score;

    [Header("Player References & Camera")]
    [SerializeField] GameObject hider;
    [SerializeField] GameObject hiderCamera;

    [SerializeField] GameObject seeker;
    [SerializeField] GameObject seekerCamera;

    [SerializeField] GameObject generalCamera;

    [Header("Hider Canvas References")]
    [SerializeField] GameObject hiderCanvas;
    [SerializeField] GameObject objectPlacedUI;

    [Header("SeekerCanvas References")]
    [SerializeField] GameObject seekerCanvas;

    [Header("General Canvas References")]
    [SerializeField] GameObject generalCanvas;
    [SerializeField] GameObject startingGeneralUI;
    [SerializeField] GameObject betweenPhaseGeneralUI;

    [Header("Animation References")]
    [SerializeField] AnimationClip _fadeOutAnim;
    [SerializeField] AnimationClip _placeFadeOutAnim;
    [SerializeField] AnimationClip _fadeOutBetweenPhaseAnim;
    [SerializeField] AnimationClip _seekerFadeOutAnim;

    Animator _generalCanvasAnimator;
    Animator _hiderCanvasAnimator;

    bool targetFound = false;

    public event Action<bool> OnGameEnded;
    void Start()
    {
        _placeObjectScript.OnPhaseEnded += PlaceFadeOut;
        _guessScript.OnPhaseEnded += GuessEnded;

        _generalCanvasAnimator = generalCanvas.GetComponent<Animator>();
        _hiderCanvasAnimator = hiderCanvas.GetComponent<Animator>();
    }

    //Do a Fadeout on the general canvas and start the place phase

    public void StartingFadeOut()
    {
        _generalCanvasAnimator.SetTrigger("FadeOut");
        StartCoroutine(WaitForStartingFadeOut(_fadeOutAnim.length));
    }
    IEnumerator WaitForStartingFadeOut(float duration)
    {
        yield return new WaitForSeconds(duration);
        generalCamera.SetActive(false);
        startingGeneralUI.SetActive(false);
        generalCanvas.SetActive(false);
        PlaceStart();
    }


    //Place phase Functions
    void PlaceStart()
    {
        hider.SetActive(true);
        hiderCanvas.SetActive(true);
        _hiderCanvasAnimator.SetTrigger("FadeIn");
        _cursorManager.SetSpecialCursor();
    }

    void PlaceFadeOut()
    {
        objectPlacedUI.SetActive(false);
        _hiderCanvasAnimator.SetTrigger("FadeOut");
        StartCoroutine(WaitForPlaceFadeOut(_placeFadeOutAnim.length));
    }

    IEnumerator WaitForPlaceFadeOut(float duration)
    {
        yield return new WaitForSeconds(2);
        PlaceEnded();
    }

    void PlaceEnded()
    {
        hider.SetActive(false);
        hiderCanvas.SetActive(false);

        _cursorManager.SetDefaultCursor();
        generalCamera.SetActive(true);
        generalCanvas.SetActive(true);
        _generalCanvasAnimator.SetTrigger("FadeInBetweenPhase");
        betweenPhaseGeneralUI.SetActive(true);
    }


    //Guess phase Functions
    public void BetweenPhaseFadeOut()
    {
        _generalCanvasAnimator.SetTrigger("FadeOutBetweenPhase");
        StartCoroutine(WaitForBetweenPhaseFadeOut(_fadeOutBetweenPhaseAnim.length));
    }
    IEnumerator WaitForBetweenPhaseFadeOut(float duration)
    {
        yield return new WaitForSeconds(duration);
        betweenPhaseGeneralUI.SetActive(false);
        generalCanvas.SetActive(false);
        GuessStart();
    }
    void GuessStart()
    {
        _score.StartGuessing = true;
        generalCamera.SetActive(false);
        seeker.SetActive(true);
        seekerCanvas.SetActive(true);
        seekerCanvas.GetComponent<Animator>().SetTrigger("SeekerFadeIn");
        _cursorManager.SetSpecialCursor();
    }

    public void GuessEnded(bool _targetFound)
    {
        _score.CalculateScore();
        targetFound = _targetFound;
        seekerCamera.GetComponent<Cam_Controler>().enabled = false;
        seeker.GetComponent<PlayerInput>().enabled = false;
        _guessScript.enabled = false;
        _cursorManager.SetDefaultCursor();
        seekerCanvas.GetComponent<Animator>().SetTrigger("SeekerFadeOut");
        StartCoroutine(WaitforSeekerFadeOut(_seekerFadeOutAnim.length));
    }

    IEnumerator WaitforSeekerFadeOut(float duration)
    {
        yield return new WaitForSeconds(duration);
        seekerCanvas.SetActive(false);
        OnGameEnded?.Invoke(targetFound);
    }

}
