using System;
using UnityEngine;

public class ChooseSize : MonoBehaviour
{
    [SerializeField] PlaceObject placeObject;

    [Header("Objects")]
    [SerializeField] GameObject smallObject;
    [SerializeField] GameObject mediumObject;
    [SerializeField] GameObject largeObject;

    [Header("Ghost Objects")]
    [SerializeField] GameObject ghostSmallObject;
    [SerializeField] GameObject ghostMediumObject;
    [SerializeField] GameObject ghostLargeObject;

    [Header("Buttons")]
    [SerializeField] GameObject smallButton;
    [SerializeField] GameObject mediumButton;
    [SerializeField] GameObject largeButton;
    [SerializeField] GameObject readyButton;

    public event Action<int> OnSizeChoosed;
    public void SmallChoose()
    {
        placeObject.SetObject(smallObject, ghostSmallObject);
        OnSizeChoosed?.Invoke(1);
        UiSetUp();
    }

    public void MediumChoose()
    {
        placeObject.SetObject(mediumObject, ghostMediumObject);
        OnSizeChoosed?.Invoke(2);
        UiSetUp();
    }

    public void LargeChoose()
    {
        placeObject.SetObject(largeObject, ghostLargeObject);
        OnSizeChoosed?.Invoke(3);
        UiSetUp();
    }

    void UiSetUp()
    {
        smallButton.SetActive(false);
        mediumButton.SetActive(false);
        largeButton.SetActive(false);
        readyButton.SetActive(true);
    }
}
