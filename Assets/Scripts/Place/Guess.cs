using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Guess : MonoBehaviour
{
    [SerializeField] LayerMask Props;
    [SerializeField] LayerMask Target;

    [SerializeField] int MaxGuess;
    [SerializeField] int RemainingGuess;

    public event Action OnTargetFound;
    public event Action<String> OnGuessFailed;

    RaycastHit hit;

    private void Start()
    {
        RemainingGuess = MaxGuess;

        OnTargetFound += SuccessfulGuess;
        OnGuessFailed += FailedGuess;
    }

    public void OnGuess(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || RemainingGuess <= 0) return;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, Target))
        {
            OnTargetFound?.Invoke();
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, Props))
        {
            OnGuessFailed?.Invoke("Prop");
        }
        else
        {
            OnGuessFailed?.Invoke("Nothing");
        }
    }

    void SuccessfulGuess()
    {
        RemainingGuess--;
        Debug.Log($"You found the target");
    }

    void FailedGuess(string str)
    {
        RemainingGuess--;
        Debug.Log($"You found: {str}");
        if (RemainingGuess <= 0)
        {
            Debug.Log($"No remaining guess");
        }
    }

    //To be deleted Then
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, Target))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.blue);
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, Props))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.black);
        }


    }
}
