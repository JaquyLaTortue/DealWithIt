using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class PlaceIndication : MonoBehaviour
{
    [Header("Hider Texts")]
    [SerializeField] TMP_Text HiderColorText;
    [SerializeField] TMP_Text HiderAdjectifText;
    [SerializeField]TMP_Text HiderFormeText;

    [Header("Seeker Texts")]
    [SerializeField] TMP_Text SeekerColorText;
    [SerializeField] TMP_Text SeekerAdjectifText;
    [SerializeField] TMP_Text SeekerFormeText;

    [Header("Indications")]
    [SerializeField] List<string> Color = new() {"Green" , "Red", "Yellow", "Blue", "Purple", "Orange", "Cyan", "White", "Black", "Grey"};
    [SerializeField] List<string> Adjectif = new() {"Stable", "Reachable", "Heavy", "Unreachable", "Tough", "Light", "Wood", "Glass", "Carpet", "Iron"};
    [SerializeField] List<string> Forme = new() {"Round", "Square", "Long", "Big", "Small", "Short", "Oval", "Medium"};

    string[] Indications = new string[3];
    void RandomChoice()
    {
        Indications[0] = Color[Random.Range(0, Color.Count - 1)];
        Indications[1] = Adjectif[Random.Range(0, Adjectif.Count - 1)];
        Indications[2] = Forme[Random.Range(0, Forme.Count - 1)];
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomChoice();
        HiderColorText.text = Indications[0];
        HiderAdjectifText.text = Indications[1];
        HiderFormeText.text = Indications[2];

        SeekerColorText.text = Indications[0];
        SeekerAdjectifText.text = Indications[1];
        SeekerFormeText.text = Indications[2];
    }
}
