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
        _ghost = Instantiate(ghost, this.transform.position, Quaternion.identity);
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            _ghost.transform.position = hit.point;
        }
    }
    public void Place(InputAction.CallbackContext ctx)
    {
        if (!ctx.started || !_canPlace) return;
        Instantiate(_object, _ghost.transform.position, Quaternion.identity);
        //_canPlace = false;
    }
}
