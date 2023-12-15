using DG.Tweening;
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

    public event Action<GameObject> OnTargetFound;
    public event Action<GameObject> OnPropGuess;
    public event Action OnFailedGuess;

    RaycastHit hit;

    private void Start()
    {
        remainingGuess = maxGuess;

        OnTargetFound += SuccessfulGuess;
        OnPropGuess += PropGuess;
        OnFailedGuess += FailedGuess;
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

    void SuccessfulGuess(GameObject go)
    {
        remainingGuess--;
        Debug.Log($"You found the target");
    }

    void PropGuess(GameObject go)
    {
        remainingGuess--;
        go.transform.DOShakePosition(1f, 0.1f, 5, 90, false, true);
        Debug.Log($"You found a prop");
        if (remainingGuess <= 0)
        {
            Debug.Log($"No remaining guess");
        }
    }

    void FailedGuess()
    {
        remainingGuess--;
        Debug.Log($"You found nothing");
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
