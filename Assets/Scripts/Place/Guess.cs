using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Guess : MonoBehaviour
{
    [SerializeField] LayerMask Props;
    [SerializeField] LayerMask Target;

    [SerializeField] int maxGuess;
    [SerializeField] int remainingGuess;

    [SerializeField] int range;

    public event Action OnTargetFound;
    public event Action<String> OnGuessFailed;

    RaycastHit hit;

    private void Start()
    {
        remainingGuess = maxGuess;

        OnTargetFound += SuccessfulGuess;
        OnGuessFailed += FailedGuess;
    }

    public void OnGuess(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || remainingGuess <= 0) return;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, Target))
        {
            OnTargetFound?.Invoke();
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, Props))
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
        remainingGuess--;
        Debug.Log($"You found the target");
    }

    void FailedGuess(string str)
    {
        remainingGuess--;
        Debug.Log($"You found: {str}");
        if (remainingGuess <= 0)
        {
            Debug.Log($"No remaining guess");
        }
    }

    //To be deleted Then
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, Target))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.blue);
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, Props))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.black);
        }


    }
}
