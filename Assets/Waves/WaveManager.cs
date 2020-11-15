using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject cart;
    [SerializeField] GameObject startWave;
    [SerializeField] GameObject text;
    [SerializeField] Transform enemySpawners;
    [SerializeField] Transform enemyTrans;
    [SerializeField] List<WaveClass> waves;

    [SerializeField]
    int waveNumber = 0;

    int spawnNumber=0;

    float timer=0;

    public bool attacking=true;
    WaveClass currentWave;
    // Start is called before the first frame update
    void Start()
    {
        //text.GetComponent<WaveText>().Display(waveNumber);
        currentWave = waves[waveNumber];
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking)
        {

        }

        if (spawnNumber<currentWave.enemies.Count && attacking)
        {
            cart.SetActive(true);
            startWave.SetActive(false);



            
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

            

            

            if (enemyTrans.childCount == 0 && attacking)
            {
                //cart.SetActive(false);
                startWave.SetActive(true);

                ShopSlot[] shopSlots = FindObjectsOfType<ShopSlot>();
                foreach (ShopSlot shopSlot in shopSlots)
                {
                    shopSlot.Restock();
                }

                text.GetComponent<WaveText>().DisplayOver();
                
                
                waveNumber++;
                spawnNumber=0;
                timer = 0;
                attacking=false;
                
                if (waveNumber >= waves.Count)
                    waveNumber--;

                currentWave = waves[waveNumber];

            }
        }
       
        
    }

    public void StartWave()
    {
        attacking=true;
        
        if (waveNumber >= waves.Count-1)
            text.GetComponent<WaveText>().Display(999);
        else 
            text.GetComponent<WaveText>().Display(waveNumber);
        
    }
}
