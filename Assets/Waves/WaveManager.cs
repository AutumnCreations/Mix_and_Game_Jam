using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] Transform enemySpawners;
    [SerializeField] Transform enemyTrans;
    [SerializeField] List<WaveClass> waves;

    [SerializeField]
    int waveNumber = 0;

    int spawnNumber=0;

    float timer=0;

    WaveClass currentWave;
    // Start is called before the first frame update
    void Start()
    {
        text.GetComponent<WaveText>().Display(waveNumber);
        currentWave = waves[waveNumber];
    }

    // Update is called once per frame
    void Update()
    {
        

        if (spawnNumber<currentWave.enemies.Count)
        {
            timer += Time.deltaTime;
            if (timer > currentWave.spawnDelay)
            {
                timer=0;
                for (int i=0;i<currentWave.number[spawnNumber];i++)
                {
                    GameObject x = Instantiate(currentWave.enemies[spawnNumber], enemySpawners.GetChild(Random.Range(0,enemySpawners.childCount)).position, Quaternion.identity);
                    x.transform.SetParent(enemyTrans);
                }

                spawnNumber++;
            }
        }
        else 
        {
            if (enemyTrans.childCount == 0)
            {
                waveNumber++;
                spawnNumber=0;
                timer = 0;
                
                if (waveNumber >= waves.Count)
                {
                    waveNumber--;
                    text.GetComponent<WaveText>().Display(999);
                }
                else 
                {
                    text.GetComponent<WaveText>().Display(waveNumber);
                }

                currentWave = waves[waveNumber];

            }
        }
       
        
    }
}
