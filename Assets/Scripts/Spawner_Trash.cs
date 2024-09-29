using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Trash : MonoBehaviour
{
    [SerializeField] private SOs_SpawnTrashData spawnerData;
    [SerializeField] private SOs_TrashData trashData;
    private float _timer = 0f;
    private bool nextTrash = true;

    private void Update()
    {
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        _timer += Time.deltaTime;

        if (_timer >= spawnerData.timeBetweenObjects) 
        {
            SpawnObjects();
            _timer = 0f;
        }
    }
    public void SpawnObjects()
    {
        float randomX = UnityEngine.Random.Range(spawnerData.minX, spawnerData.maxX);
        Vector3 positionObject = transform.position + spawnerData.spawnPointOffset; 
        positionObject.x = randomX;

        GameObject spawnObject = null;
        if (nextTrash)
        {
            spawnObject = spawnerData.asteroidPrefab; 
            nextTrash = false;
        }
        else
        {
            spawnObject = spawnerData.satellitePrefab; 
            nextTrash = true;
        }
        GameObject instantiatedObject = Instantiate(spawnObject, positionObject, Quaternion.identity);

        float randomRotationX = UnityEngine.Random.Range(trashData.minRotationX, trashData.maxRotationX);
        float randomRotationY = UnityEngine.Random.Range(trashData.minRotationY, trashData.maxRotationY);
        float randomRotationZ = UnityEngine.Random.Range(trashData.minRotationZ, trashData.maxRotationZ);

        Quaternion randomRotation = Quaternion.Euler(randomRotationX, randomRotationY, randomRotationZ);
        instantiatedObject.transform.rotation = randomRotation;
    }
}
