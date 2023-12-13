using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceObject : MonoBehaviour
{
    //Store the Object you want to place in the scene in the inspector
    [SerializeField] GameObject _object;
    [SerializeField] GameObject ghost;
    GameObject _ghost;
    public LayerMask layerMask;

    bool _canPlace = true;

    RaycastHit hit;

    private void Start()
    {
        _ghost = Instantiate(ghost, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.blue);
            _ghost.SetActive(true);
            _ghost.transform.position = hit.point;
            _canPlace = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.red);
            _ghost.SetActive(false);
            _canPlace = false;
        }

    }
    public void OnPlace(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || !_canPlace) return;
        Instantiate(_object, _ghost.transform.position, Quaternion.identity);
        //_canPlace = false;
    }
}
