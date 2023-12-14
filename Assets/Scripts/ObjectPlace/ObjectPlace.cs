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
    List<string> Adjectif = new() {"Stable", "reachable", "Heavy", "Beautifull"};
    List<string> Forme = new() {"Round", "Square", "Triangle", "Star"};

    // Start is called before the first frame update
    void Start()
    {
        //ColorText.text = ();
        //AdjectifText.text = ();
        //FormeText.text = ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
