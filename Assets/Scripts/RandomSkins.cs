using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkins : MonoBehaviour
{
    [Header("Prop List")]
    [SerializeField] public List<GameObject> props = new();
    [SerializeField] public List<Material> Skins = new();

    [Header("Toggle if the prop is a composed mesh")]
    public bool compositeMeshe = false;
    public int MeshesCount = 0;
    int index = 1;
    Material actualMaterial;
    private Material RandomMaterial()
    {
        Material Materiaux = Skins[Random.Range(0, Skins.Count)];
        return Materiaux;
    }

    void Start()
    {
        if (!compositeMeshe)
        {
            for (int i = 0; i <= props.Count - 1; i++)
            {
                props[i].GetComponent<MeshRenderer>().material = RandomMaterial();
            }
        }
        else
        {
            for (int i = 0; i < props.Count; i++)
            {
                if (index == 1)
                {
                    actualMaterial = RandomMaterial();
                    props[i].GetComponent<MeshRenderer>().material = actualMaterial;
                    index++;
                }
                else if (index < MeshesCount)
                {
                    props[i].GetComponent<MeshRenderer>().material = actualMaterial;
                    index++;
                }
                else if (index == MeshesCount)
                {
                    props[i].GetComponent<MeshRenderer>().material = actualMaterial;
                    index = 1;
                }
            }
        }
    }
}