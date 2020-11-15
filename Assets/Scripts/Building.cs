using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("Building Stats")]
    [SerializeField] bool spawner=true;
    [SerializeField] float timeToSpawn = 3;


    [Header("References")]
    [SerializeField] public GameObject specialBallPrefab;
    [SerializeField] GameObject unthrownBallPrefab;
    [SerializeField] Transform ballSpawnPosition;

    private float currentTime = 0;

    CountCollisions countCollisions;

    void Start()
    {
        countCollisions = GetComponent<CountCollisions>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (spawner && currentTime > timeToSpawn)
        {
            currentTime = 0;
            Instantiate(unthrownBallPrefab, ballSpawnPosition.position - transform.forward, Quaternion.identity);
        }
    }

    void PlaceBuilding()
    {
        bool openSpace = true;
        foreach (GameObject collidedObject in countCollisions.collisions)
        {
            if (collidedObject.tag == "buildingPrefab")
            {
                openSpace = false;
                break;
            }
        }

    }
}
