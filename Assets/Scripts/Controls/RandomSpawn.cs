using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints = new GameObject[6];

    public Transform SetRandomSpawn()
    {
        GameObject ChoosedSpawn = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
        return ChoosedSpawn.transform;
    }
}
