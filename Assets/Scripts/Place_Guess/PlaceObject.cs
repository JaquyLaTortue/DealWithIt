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
    Vector3 objectOffSet = new();
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

    [SerializeField] bool PlaceMode;

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
            _ghost.SetActive(true);

            if (PlaceMode) //Turn the ghost object to the normal of the surface
            {
                _ghost.transform.position = hit.point;
                _ghost.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            else //Set an offset to the object to place it on the wall
            {
                if (hit.normal.y > .5f)
                {
                    _ghost.transform.position = hit.point;
                }
                else if (hit.normal.x > .5f)
                {
                    _ghost.transform.position = new Vector3(hit.point.x + objectOffSet.x, hit.point.y, hit.point.z);
                }
                else if (hit.normal.z > .5f)
                {
                    _ghost.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z + objectOffSet.z);
                }
                else if (hit.normal.y < -.5f)
                {
                    _ghost.transform.position = new Vector3(hit.point.x, hit.point.y + objectOffSet.y, hit.point.z);
                }
                else if (hit.normal.x < -.5f)
                {
                    _ghost.transform.position = new Vector3(hit.point.x - objectOffSet.x, hit.point.y, hit.point.z);
                }
                else if (hit.normal.z < -.5f)
                {
                    _ghost.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z - objectOffSet.z);
                }
            }
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

    public void SetOffset(Vector3 offset)
    {
        objectOffSet = offset;
    }

    //Place the object where the ghost object is
    public void OnPlace(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || !_canPlace) return;
        _placedObject = Instantiate(_object, _ghost.transform.position, _ghost.transform.rotation);
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

    public void ChangePlaceMode(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;
        PlaceMode = !PlaceMode;
    }
}