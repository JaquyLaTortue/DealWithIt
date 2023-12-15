using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPlace : MonoBehaviour
{
    public TMP_Text ColorText;
    public TMP_Text AdjectifText;
    public TMP_Text FormeText;


    List<string> Color = new() {"Green" , "Red", "Yellow", "Bue", "Purple", "Orange", "Cyan", "White", "Black", "Grey"};
    List<string> Adjectif = new() {"Stable", "Reachable", "Heavy", "Unreachable", "Tough", "Light", "Wood", "Paper", "Carpet", "Iron"};
    List<string> Forme = new() {"Round", "Square", "Triangle", "Star", "Long", "Big", "Small", "Short", "Oval", "Medium"};

    int ChoixRandom()
    {
        int Choix = Random.Range(0, 9);
        return Choix;
    }

    // Start is called before the first frame update
    void Start()
    {
        ColorText.text = ($"- {Color[ChoixRandom()]}");
        AdjectifText.text = ($"- {Adjectif[ChoixRandom()]}");
        FormeText.text = ($"- {Forme[ChoixRandom()]}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
