using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int health = 1;
    [SerializeField] int damage = 1;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime;
    }

    public int DealDamage()
    {
        print(string.Format("{0} dealt {1} damage.", gameObject.name, damage));
        return damage;
    }
}
