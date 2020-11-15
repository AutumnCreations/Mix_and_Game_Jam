using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawner : MonoBehaviour
{

    WaveManager waveManager;
    [SerializeField] bool moveLeft=false;
    [SerializeField] GameObject coinPrefab;

    float timeToCoin = 5;
    // Start is called before the first frame update
    void Start()
    {
        waveManager= FindObjectOfType<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waveManager.attacking)
        {
            timeToCoin -= Time.deltaTime;
            if (timeToCoin<0)
            {
                timeToCoin=5;
                GameObject newCoin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            
                newCoin.GetComponent<Coin>().moveLeft = moveLeft;
            }
        }
    }
}
