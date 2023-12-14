using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseObjects : MonoBehaviour
{

    public GameObject CanvasChooseObjects;


    // Start is called before the first frame update
    void Start()
    {
        CanvasChooseObjects.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartHunter()
    {
        CanvasChooseObjects.SetActive(false);
    }
}
