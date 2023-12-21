using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkins : MonoBehaviour
{
    [SerializeField] public List<GameObject> Objects = new() { };
    [SerializeField] public List<Material> Skins = new() { };

    private Material RandomMaterial()
    {
        Material Materiaux = Skins[Random.Range(0, Skins.Count - 1)];
        return Materiaux;
    }

    void Start()
    {
        for(int i = 0; i <= Objects.Count - 1; i++ )
        {

            GameObject SelectedObjects = Objects[i];

            SelectedObjects.GetComponent<SpriteRenderer>().material = RandomMaterial();
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
