using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Guess : MonoBehaviour
{
    [SerializeField] LayerMask Props;
    [SerializeField] LayerMask Target;

    public int maxGuess;
    public int remainingGuess { get; private set; }

    [SerializeField] int range;

    [SerializeField] TMP_Text guessResult;

    RaycastHit hit;

    //Events for the different guesses possible
    public event Action<GameObject> OnTargetFound;
    public event Action<GameObject> OnPropGuess;
    public event Action OnFailedGuess;

    //Events triggered when the phase is over
    public event Action<bool> OnPhaseEnded;

    private void Start()
    {
        remainingGuess = maxGuess;

        OnTargetFound += SuccessfulGuess;
        OnPropGuess += PropGuess;
        OnFailedGuess += FailedGuess;

        guessResult.text = $"Remaining Guess : {remainingGuess}";
    }

    public void OnGuess(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || remainingGuess <= 0) return;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, Target))
        {
            OnTargetFound?.Invoke(hit.collider.gameObject);
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, Props))
        {
            OnPropGuess?.Invoke(hit.collider.gameObject);

        }
        else
        {
            OnFailedGuess?.Invoke();
        }
    }

    //Called when the player found the target
    void SuccessfulGuess(GameObject go)
    {
        remainingGuess--;
        go.transform.DOShakeRotation(1f, 90, 10, 90, false);
        guessResult.text = $"Remaining Guess : {remainingGuess}\n" +
            $"You found the target";
        GuessEnd(true);
    }


    //Called when the player failed a guess to a prop
    void PropGuess(GameObject go)
    {
        remainingGuess--;
        go.transform.DOShakePosition(1f, 0.1f, 10, 90, false, true);
        guessResult.text = $"Remaining Guess : {remainingGuess}\n"
            + "You found a prop";
        if (remainingGuess <= 0)
        {
            GuessEnd(false);
        }
    }

    //Called when the player failed a guess on nothing 
    void FailedGuess()
    {
        guessResult.text = $"Remaining Guess : {remainingGuess}\n" +
            "Try again You found nothing and you can't find air ou a wall";
    }

    void GuessEnd(bool TargetFound)
    {

        if (TargetFound)
        {
            Debug.Log($"You found the target");
            OnPhaseEnded?.Invoke(true);
        }
        else
        {
            Debug.Log($"You didn't find the target");
            OnPhaseEnded?.Invoke(false);
        }
    }
}
