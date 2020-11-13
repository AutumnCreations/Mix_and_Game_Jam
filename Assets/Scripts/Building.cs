using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    [SerializeField] GameObject unthrownBallPrefab;
    [SerializeField] float timeToSpawn = 3;
    float currentTime=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeToSpawn)
        {
            currentTime=0;
            Instantiate(unthrownBallPrefab, transform.position - transform.forward, Quaternion.identity);
        }
    }
}
