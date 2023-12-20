using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RulesDisplay : MonoBehaviour
{
    [Header("Rules Text")]
    [SerializeField] TMP_Text hiderRules;
    [SerializeField] TMP_Text seekerRules;

    [Header("References")]
    [SerializeField] Rebind _rebind;

    private void Start()
    {
        UpdateRules();
    }
    public void UpdateRules()
    {
        UpdateHiderRules();
        UpdateSeekerRules();
    }
    void UpdateHiderRules()
    {
        hiderRules.text =
            $"- He can Choose the size of the object he will hide \n" +
            $"\n" +
            $"- He must follow the instructions displayed so the seeker will have a chance to find it \n" +
            $"\n" +
            $"- He can place the object he choosed by clicking {InputControlPath.ToHumanReadableString(_rebind._placeAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)} \n" +
            $"\n" +
            $"- He can cancel the placement of the object by clicking {InputControlPath.ToHumanReadableString(_rebind._cancelPlacementAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)} " +
            $"and validate his placement by clicking {InputControlPath.ToHumanReadableString(_rebind._validatePlacementAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)} \n" +
            $"\n" +
            $"- He can change the placement mode by clicking {InputControlPath.ToHumanReadableString(_rebind._changePlacementAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)}";
    }

    void UpdateSeekerRules()
    {
        seekerRules.text =
            $"- He have a limited amount of time to find the object that the hider placed \n" +
            $"\n" +
            $"- He have to follow the instructions displayed to find the object \n" +
            $"\n" +
            $"- He can try to guess if an object is the one that the hider placed by clicking {InputControlPath.ToHumanReadableString(_rebind._guessAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice)} \n" +
            $"\n" +
            $"- But he have a certain amount of tries \n" +
            $"\n" +
            $"- He can follow the sound that play regularly to find the object";
    }
}
