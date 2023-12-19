using System.Collections;
using UnityEngine;

public class Sons : MonoBehaviour
{
    AudioSource myAudio;
    [SerializeField] int timeToWait = 20;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(bang());
    }

    IEnumerator bang()
    {
        yield return new WaitForSeconds(timeToWait);
        myAudio.Play();
        StartCoroutine(bang());
    }
}
