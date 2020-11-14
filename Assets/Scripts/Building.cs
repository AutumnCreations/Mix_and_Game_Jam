using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    [Header("Building Stats")]
    [SerializeField] float timeToSpawn = 3;

    [Header("References")]
    [SerializeField] GameObject unthrownBallPrefab;
    [SerializeField] Transform ballSpawnPosition;

    private float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeToSpawn)
        {
            currentTime = 0;
            Instantiate(unthrownBallPrefab, ballSpawnPosition.position - transform.forward, Quaternion.identity);
        }
    }
}
