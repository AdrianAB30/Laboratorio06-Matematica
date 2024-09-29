using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerData", menuName = "ScriptableObjects/SpawnerData", order = 1)]
public class SOs_SpawnTrashData : ScriptableObject
{
    public GameObject asteroidPrefab;
    public GameObject satellitePrefab;
    public float timeBetweenObjects;
    public Vector3 spawnPointOffset = new Vector3(0, 0, 50);
    public float rangeX = 20f;

    public float minX = -2.5f;
    public float maxX = 14.10f;
}
