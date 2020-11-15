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

    public void SellKit()
    {
        currentKit = null;
        currentTime = 0;
    }

    public void Restock()
    {
        kitToDispense = kits[Random.Range(0, kits.Length)];
        currentKit = Instantiate(kitToDispense, transform.position, Quaternion.identity);
    }
}
