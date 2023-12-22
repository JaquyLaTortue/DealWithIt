using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rebind : MonoBehaviour
{
    [Header("Hider Rebind Text")]
    [SerializeField] TMP_Text placeRebindText;
    [SerializeField] TMP_Text cancelPlacementRebindText;
    [SerializeField] TMP_Text validatePlacementRebindText;
    [SerializeField] TMP_Text ChangePlacementRebindText;
    [SerializeField] TMP_Text OpenHiderText;
    [SerializeField] TMP_Text CloseHiderText;

    [Header("Seeker Rebind Text")]
    [SerializeField] TMP_Text guessRebindText;
    [SerializeField] TMP_Text OpenSeekerText;
    [SerializeField] TMP_Text CloseSeekerText;

    [Header("Hider Input Actions")]
    public InputActionReference _placeAction;
    public InputActionReference _cancelPlacementAction;
    public InputActionReference _validatePlacementAction;
    public InputActionReference _changePlacementAction;
    public InputActionReference _openHiderAction;
    public InputActionReference _closeHiderAction;


    [Header("Seeker Input Actions")]
    public InputActionReference _guessAction;
    public InputActionReference _openSeekerAction;
    public InputActionReference _closeSeekerAction;


    [Header("Rebind UI")]
    [SerializeField] GameObject RebindUI;

    InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private void Start()
    {
        UpdateText();
    }
    public void RebindKeyboard(InputActionReference _ref)
    {
        InputAction _action = _ref.action;
        _action.Disable();
        RebindUI.SetActive(true);
        rebindingOperation = _ref.action.PerformInteractiveRebinding(0)
            .WithControlsExcluding("Gamepad")
            .WithControlsExcluding("Touchpad")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(_action))
            .Start();
    }

    void RebindComplete(InputAction _action)
    {
        InputBinding _binding = _action.bindings[0];
        _binding.overridePath = rebindingOperation.action.bindings[0].effectivePath;
        _action.ApplyBindingOverride(0, _binding);

        _action.Enable();
        rebindingOperation.Dispose();
        UpdateText();
        RebindUI.SetActive(false);
    }

    void UpdateText()
    {
        placeRebindText.text = $"Place : {InputControlPath.ToHumanReadableString(_placeAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";

        cancelPlacementRebindText.text = $"Cancel Placement : {InputControlPath.ToHumanReadableString(_cancelPlacementAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";

        validatePlacementRebindText.text = $"Validate Placement : {InputControlPath.ToHumanReadableString(_validatePlacementAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";

        ChangePlacementRebindText.text = $"Change Placement   Mode : {InputControlPath.ToHumanReadableString(_changePlacementAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";

        guessRebindText.text = $"Guess : {InputControlPath.ToHumanReadableString(_guessAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";

        OpenHiderText.text = $"Open for Hider : {InputControlPath.ToHumanReadableString(_openHiderAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";

        CloseHiderText.text = $"Close for Hider : {InputControlPath.ToHumanReadableString(_closeHiderAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";

        OpenSeekerText.text = $"Open for Seeker : {InputControlPath.ToHumanReadableString(_openSeekerAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";

        CloseSeekerText.text = $"Close for Seeker : {InputControlPath.ToHumanReadableString(_closeSeekerAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";
    }
}
