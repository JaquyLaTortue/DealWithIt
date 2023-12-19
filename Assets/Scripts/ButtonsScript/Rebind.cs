using System;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rebind : MonoBehaviour
{
    [Header("Rebind Text")]
    [SerializeField] TMP_Text placeRebindText;
    [SerializeField] TMP_Text cancelPlacementRebindText;
    [SerializeField] TMP_Text validatePlacementRebindText;
    [SerializeField] TMP_Text ChangePlacementRebindText;
    [SerializeField] TMP_Text guessRebindText;

    [Header("Input Actions")]
    [SerializeField] InputActionReference _placeAction;
    [SerializeField] InputActionReference _cancelPlacementAction;
    [SerializeField] InputActionReference _validatePlacementAction;
    [SerializeField] InputActionReference _changePlacementAction;
    [SerializeField] InputActionReference _guessAction;

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

        //Debug.Log(rebindingOperation.action.bindings[0].effectivePath);
        _action.Enable();
        rebindingOperation.Dispose();
        //Debug.Log(InputControlPath.ToHumanReadableString(_action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice));
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
    }
}
