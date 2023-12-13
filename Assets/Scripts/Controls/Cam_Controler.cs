using UnityEngine;
using UnityEngine.UI;

public class Cam_Controler : MonoBehaviour
{
    [SerializeField] private float Sensitivity = 100f;

    [SerializeField] private Transform Orientation;

    [SerializeField] private Texture2D CursorInGame;

    float xRotation;
    float yRotation;

    private void Start()
    {
        //Cursor.SetCursor(CursorInGame, new Vector2(0.5f, 0.5f), CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }


    private void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        yRotation += Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        Orientation.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
