using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [Header("Controllers")]
    //The Player input to disable when the game is paused
    [SerializeField] PlayerInput _hiderPlayerInput;
    [SerializeField] Cam_Controler _hiderCamController;
    [SerializeField] PlayerInput _seekerPlayerInput;
    [SerializeField] Cam_Controler _seekerCamController;

    //The pause menu that will be displayed when the game is paused
    [SerializeField] GameObject _hiderPauseMenu;
    [SerializeField] GameObject _seekerPauseMenu;

    //The timer that will be paused when the game is paused
    [SerializeField] TimeLimit _timeLimit;
    [SerializeField] CursorManager _cursorManager;
    public void PauseHider(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) { return; }
        _hiderPauseMenu.SetActive(true);
        _hiderPlayerInput.enabled = false;
        _hiderCamController.enabled = false;

        _cursorManager.SetDefaultCursor();

        _timeLimit.started = false;
    }
    public void PauseSeeker(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) { return; }
        _seekerPauseMenu.SetActive(true);
        _seekerPlayerInput.enabled = false;
        _seekerCamController.enabled = false;

        _cursorManager.SetDefaultCursor();

        _timeLimit.started = false;
    }

    public void Resume()
    {
        _hiderPauseMenu.SetActive(false);
        _hiderPlayerInput.enabled = true;
        _hiderCamController.enabled = true;

        _seekerPauseMenu.SetActive(false);
        _seekerPlayerInput.enabled = true;
        _seekerCamController.enabled = true;

        _cursorManager.SetSpecialCursor();

        _timeLimit.started = true;
    }
}
