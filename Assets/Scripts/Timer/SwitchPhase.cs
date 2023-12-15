using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPhase : MonoBehaviour
{
    [SerializeField] Guess _guessScript;
    [SerializeField] PlaceObject _placeObjectScript;

    private void Start()
    {
        //_guessScript.OnPhaseEnded += GuessEnded;
        //_placeObjectScript.OnPhaseEnded += PlaceEnded;
    }

    void GuessEnded()
    {
        _guessScript.transform.parent.gameObject.SetActive(false);
        _placeObjectScript.transform.parent.gameObject.SetActive(true);
    }

    void PlaceEnded()
    {
        _placeObjectScript.transform.parent.gameObject.SetActive(false);
    }
}
