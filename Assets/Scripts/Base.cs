using UnityEngine;

public class Base : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] int health = 20;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        print("Goodbye!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.GetComponent<Enemy>().DealDamage());
            print(health);
        }
    }
}
