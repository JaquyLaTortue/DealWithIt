using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SwitchPhase : MonoBehaviour
{
    [Header("Scripts References")]
    [SerializeField] Guess _guessScript;
    [SerializeField] PlaceObject _placeObjectScript;
    [SerializeField] CursorManager _cursorManager;

    [Header("Player References & Camera")]
    [SerializeField] GameObject hider;
    [SerializeField] GameObject seeker;
    [SerializeField] Camera generalCamera;

    [Header("Canvas References")]
    [SerializeField] GameObject hiderCanvas;
    [SerializeField] GameObject seekerCanvas;
    [SerializeField] GameObject generalCanvas;

    [Header("Animation References")]
    [SerializeField] AnimationClip _FadeIn;
    Animator _generalCanvasAnimator;

    private void Start()
    {
        //_guessScript.OnPhaseEnded += GuessEnded;
        //_placeObjectScript.OnPhaseEnded += PlaceEnded;

        _generalCanvasAnimator = generalCanvas.GetComponent<Animator>();
    }

    public void FadeIn()
    {
        _generalCanvasAnimator.SetTrigger("FadeIn");
        StartCoroutine(WaitForFadeOut(_FadeIn.length));
    }

    public void PlaceStart()
    {
        hider.SetActive(true);
        _cursorManager.SetSpecialCursor();
    }

    public void GuessStart()
    {

    }

    public void PlaceEnded()
    {
        _cursorManager.SetDefaultCursor();
        _placeObjectScript.transform.parent.gameObject.SetActive(false);
        _guessScript.transform.parent.gameObject.SetActive(true);
    }

    public void GuessEnded()
    {
        _guessScript.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator WaitForFadeOut(float duration)
    {
        yield return new WaitForSeconds(duration);
        generalCamera.gameObject.SetActive(false);
        PlaceStart();
    }

}
