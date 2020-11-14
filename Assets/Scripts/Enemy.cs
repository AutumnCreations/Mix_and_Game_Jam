using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int health = 1;
    [SerializeField] int damage = 1;
    [SerializeField] float speed = .5f;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void Die()
    {
        Destroy(gameObject.GetComponent<Collider2D>());
        StartCoroutine("WaitToDie");
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(1f);
        print(gameObject.name + " died.");
        Destroy(gameObject);
    }

    private void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Die();
        }
    }

    public int DealDamage()
    {
        print(string.Format("{0} dealt {1} damage.", gameObject.name, damage));
        return damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            TakeDamage(collision.gameObject.GetComponent<Ball>().damage);
        }
    }
}
