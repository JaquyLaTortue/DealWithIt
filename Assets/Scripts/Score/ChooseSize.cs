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

    [Header("Objects Offsets")]
    [SerializeField] Vector3 smallOffset;
    [SerializeField] Vector3 mediumOffset;
    [SerializeField] Vector3 largeOffset;

    [Header("Buttons")]
    [SerializeField] GameObject readyUI;

    public event Action<int> OnSizeChoosed;
    public void SmallChoose()
    {
        placeObject.SetObject(smallObject, ghostSmallObject);
        placeObject.SetOffset(smallOffset);
        OnSizeChoosed?.Invoke(1);
    }

    public void MediumChoose()
    {
        placeObject.SetObject(mediumObject, ghostMediumObject);
        placeObject.SetOffset(mediumOffset);
        OnSizeChoosed?.Invoke(2);
    }

    public void LargeChoose()
    {
        placeObject.SetObject(largeObject, ghostLargeObject);
        placeObject.SetOffset(largeOffset);
        OnSizeChoosed?.Invoke(3);
    }
}
