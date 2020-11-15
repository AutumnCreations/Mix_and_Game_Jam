using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] BuildingKit[] kits;
    [SerializeField] float restockRate = 10f;
    public BuildingKit currentKit;

    private BuildingKit kitToDispense;
    private float currentTime = 0;


    //void Start()
    //{
    //    kitToDispense = kits[Random.Range(0, kits.Length - 1)];
    //    currentKit = Instantiate(kitToDispense, transform.position, Quaternion.identity);
    //}

    void Update()
    {
        if (!currentKit)
        {
            if (currentTime >= restockRate)
            {
                kitToDispense = kits[Random.Range(0, kits.Length - 1)];
                currentKit = Instantiate(kitToDispense, transform.position, Quaternion.identity);
            }
            currentTime += Time.deltaTime;
        }
    }

    public void SellKit()
    {
        currentKit = null;
        currentTime = 0;
    }
}
