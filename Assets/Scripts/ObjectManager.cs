using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectManager : MonoBehaviour
{

    public List<GameObject> objectPool = new List<GameObject>();
    public float objectSpawnRateSeconds = 2;

    public float objectGravityScale = 0.01f;
    public float cameraWidthInUnits; 

    void Start()
    {
        cameraWidthInUnits = FindObjectOfType<Camera>().orthographicSize * 2 * FindObjectOfType<Camera>().aspect;
        InvokeRepeating("SpawnRandomObject", 0f, objectSpawnRateSeconds);
    }

    void SpawnRandomObject()
    {
        GameObject randomObjectFromPool = objectPool[UnityEngine.Random.Range(0, objectPool.Count)];
        float randomXPositionInViewport = UnityEngine.Random.Range(-cameraWidthInUnits / 2, cameraWidthInUnits / 2);

        Vector2 objectSpawnerPosition = gameObject.transform.position;
        Vector2 newObjectPosition = new Vector2(randomXPositionInViewport, objectSpawnerPosition.y);

        Instantiate(randomObjectFromPool, newObjectPosition, Quaternion.identity);
        randomObjectFromPool.GetComponent<Rigidbody2D>().gravityScale = objectGravityScale;
    }

    
}
