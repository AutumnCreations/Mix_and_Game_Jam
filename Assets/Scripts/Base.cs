using UnityEngine;

public class Base : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] public int health = 20;
    [SerializeField] public int gold = 30;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GetGold(int amount)
    {
        gold += amount;
    }

    public bool SpendGold(int amount)
    {
        if (amount > gold)
        {
            return false;
        }
        else 
        {
            gold -= amount;
            return true;
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

            Destroy(collision.gameObject);
        }
    }
}
