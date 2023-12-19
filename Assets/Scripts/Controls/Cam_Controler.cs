using UnityEngine;

public class Cam_Controler : MonoBehaviour
{
    [SerializeField] private float Sensitivity = 100f;

    [SerializeField] private Transform Orientation;

    float xRotation;
    float yRotation;
    Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        xRotation -= Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        yRotation += Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        Orientation.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
