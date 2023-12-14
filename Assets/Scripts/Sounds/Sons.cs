using System.Collections;
using UnityEngine;

public class Sons : MonoBehaviour
{
    AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(bang());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator bang()
    {
        yield return new WaitForSeconds(1);
        myAudio.Play();
        StartCoroutine(bang());
    }
}
