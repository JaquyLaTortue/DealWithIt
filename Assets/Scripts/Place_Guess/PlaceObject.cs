using System;
using TMPro;
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
    [SerializeField] PlayerInput _playerInput;

    GameObject _placedObject;

    RaycastHit hit;

    //UI to show when the object is placed
    [SerializeField] GameObject _objectPlacedUI;
    [SerializeField] TMP_Text _validateText;
    [SerializeField] TMP_Text _cancelText;

    //Events triggered when the phase is over
    public event Action OnPhaseEnded;

    private void Update()
    {
        //Display a ghost object to show where the object will be placed if it is possible
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask) && _placedObject == null)
        {
            if (_ghost == null)
            {
                _ghost = Instantiate(ghost, hit.point, Quaternion.identity);
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.blue);
            _ghost.transform.position = hit.normal;
            _ghost.SetActive(true);
            _ghost.transform.position = hit.point;
            _canPlace = true;
        }
        else //If the object can't be placed, hide the ghost object
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.red);
            if (_ghost != null) _ghost.SetActive(false);
            _canPlace = false;
        }
    }

    public void SetObject(GameObject objectToPlace, GameObject ghostObject)
    {
        _object = objectToPlace;
        ghost = ghostObject;
    }

    //Place the object where the ghost object is
    public void OnPlace(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || !_canPlace) return;
        _placedObject = Instantiate(_object, _ghost.transform.position, Quaternion.identity);
        _canPlace = false;
        _objectPlacedUI.SetActive(true);
        _validateText.text = $"Press ({InputControlPath.ToHumanReadableString(_playerInput.actions["ValidatePlacement"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}) to validate";
        _cancelText.text = $"Press ({InputControlPath.ToHumanReadableString(_playerInput.actions["CancelPlacement"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}) to cancel";
    }

    //Destroy the object place if the player wan't to change it
    public void CancelPlacement(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || _placedObject == null) return;
        Destroy(_placedObject);
        _placedObject = null;
        _objectPlacedUI.SetActive(false);
    }

    //Validate the placement and end the phase
    public void ValidatePlacement(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || _placedObject == null) return;
        OnPhaseEnded?.Invoke();
    }
}