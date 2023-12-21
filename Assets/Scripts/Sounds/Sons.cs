using System.Collections;
using UnityEngine;

public class Sons : MonoBehaviour
{
    AudioSource myAudio;
    public AudioClip[] myclips = new AudioClip[3];
    public AudioClip[] lostSounds = new AudioClip[3];
    [SerializeField] int timeToWait = 45;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayOneShot(myclips[Random.Range(0,myclips.Length)]);
        StartCoroutine(bang());
    }

    IEnumerator bang()
    {
        yield return new WaitForSeconds(timeToWait);
        myAudio.PlayOneShot(lostSounds[Random.Range(0,lostSounds.Length)]);
        StartCoroutine(bang());
    }
}
