using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Cursor Textures")]
    [SerializeField] Texture2D DefaultCursorTexture;
    [SerializeField] Texture2D pointCursorTexture;

    public void SetSpecialCursor()
    {
        Cursor.SetCursor(pointCursorTexture, new Vector2(pointCursorTexture.width/2, pointCursorTexture.height/2), CursorMode.ForceSoftware);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.None;
    }
}
