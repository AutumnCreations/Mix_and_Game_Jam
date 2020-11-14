using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int health = 3;
    [SerializeField] int damage = 1;
    [SerializeField] float speed = .5f;
    [SerializeField] float rotationSpeed = 1f;
    [Tooltip("Minimum force to add to the ball when colliding with a peg")]
    [SerializeField] float randomOffsetMin = .01f;
    [Tooltip("Maximum force to add to the ball when colliding with a peg")]
    [SerializeField] float randomOffsetMax = .1f;

    private float xOffset;

    private ExtraBounce bounce;
    private Collider2D lastPeg;
    private Rigidbody2D enemyBody;

    Transform playerBaseTransform;

    private void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        bounce = GetComponent<ExtraBounce>();

        playerBaseTransform = FindObjectOfType<Base>().transform;
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

    }

    void FixedUpdate()
    {
        /*
        
        enemyBody.MovePosition ( transform.forward * (speed) * Time.deltaTime );
        // += transform.up * speed * Time.deltaTime;

        Vector2 direction = (playerBaseTransform.position - transform.position).normalized;
        float ang = Vector2.Angle(transform.position, (new Vector2(transform.position.x, transform.position.y)+direction) );

        enemyBody.rotation = ang;//Mathf.Lerp(enemyBody.rotation, ang, Time.deltaTime * rotationSpeed);

        */
    }

    private void Die()
    {
        FindObjectOfType<Base>().GetGold(1);
        Destroy(gameObject.GetComponent<Collider2D>());
        //Destroy(gameObject.GetComponent<Collider2D>());
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
        bounce.textMesh.text = damageTaken.ToString();
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
        else if (collision.gameObject.CompareTag("Peg"))
        {
            if (lastPeg == null || lastPeg != collision.collider)
            {
                xOffset = Random.Range(randomOffsetMin, randomOffsetMax);
                //Returns xOffset randomly as positive or negative
                xOffset *= Random.Range(0, 2) * 2 - 1;
            }
            enemyBody.AddForce(new Vector2(xOffset, 0));

            lastPeg = collision.collider;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            transform.localRotation = Quaternion.Inverse(transform.localRotation);
        }
    }
}
