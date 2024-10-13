using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnRate;

    private float SpawnTime;

    void Update()
    {
        if(SpawnTime < Time.time)
        {
            Instantiate(prefab);
            SpawnTime = Time.time + spawnRate;
        }
    }
}
