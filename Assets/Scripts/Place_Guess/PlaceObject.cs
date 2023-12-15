using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceObject : MonoBehaviour
{
    //Store the Object you want to place in the scene in the inspector
    [SerializeField] GameObject _object;
    [SerializeField] GameObject ghost;
    GameObject _ghost;
    public LayerMask layerMask;
    [SerializeField] int range = 15;
    bool _canPlace = true;

    [SerializeField] CursorManager _cursorManager;

    GameObject _placedObject;

    RaycastHit hit;

    //Events triggered when the phase is over
    public event Action OnPhaseEnded;
    public event Action OnObjectPlaced;
    public event Action OnObjectPlacementCancelled;

    private void Start()
    {
        _ghost = Instantiate(ghost, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask) && _placedObject==null)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.blue);
            _ghost.SetActive(true);
            _ghost.transform.position = hit.point;
            _canPlace = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.red);
            _ghost.SetActive(false);
            _canPlace = false;
        }
    }
    public void OnPlace(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || !_canPlace) return;
        _placedObject = Instantiate(_object, _ghost.transform.position, Quaternion.identity);
        _canPlace = false;
        _cursorManager.SetDefaultCursor();
        OnObjectPlaced?.Invoke();
    }

    public void CancelPlacement()
    {
        Destroy(_placedObject);
        _placedObject = null;
        _cursorManager.SetSpecialCursor();
        OnObjectPlacementCancelled?.Invoke();
    }

    public void ValidatePlacement()
    {
        OnPhaseEnded?.Invoke();
    }
}