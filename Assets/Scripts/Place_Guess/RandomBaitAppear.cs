using UnityEngine;

public class RandomBaitAppear : MonoBehaviour
{
    [SerializeField] GameObject[] baits = new GameObject[0];

    private void Start()
    {
        int randomint = Random.Range(40, baits.Length-30);
        Debug.Log(randomint);
        for (int i = 0; i < randomint; i++)
        {
            GameObject CurrentBait = baits[Random.Range(0, randomint)];

            CurrentBait.SetActive(true);
        }
    }
}
