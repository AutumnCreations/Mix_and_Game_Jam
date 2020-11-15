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
    [SerializeField] GameObject vfxParticleSystem;
    [SerializeField] float durationOfExplosion;

    private float xOffset;

    private ExtraBounce bounce;
    private Collider2D lastPeg;
    private Rigidbody2D enemyBody;

    Transform playerBaseTransform;

     AudioSource audioSource;

    [SerializeField] AudioClip audioClip;

    private void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        bounce = GetComponent<ExtraBounce>();

        playerBaseTransform = FindObjectOfType<Base>().transform;

         audioSource = FindObjectOfType<AudioSource>();
    }

    void Update()
    {
        

    }

    void FixedUpdate()
    {
        //Point towards middle/top

        float AngleRad = Mathf.Atan2(playerBaseTransform.transform.position.y - transform.position.y, playerBaseTransform.transform.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad - 90;
        enemyBody.SetRotation(AngleDeg);

        enemyBody.position += new Vector2(transform.up.x, transform.up.y) * speed * Time.deltaTime;
    }

    private void Die()
    {
        FindObjectOfType<Base>().GetGold(1);
        Destroy(gameObject);
        GameObject explosion = Instantiate(vfxParticleSystem, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);

        //Destroy(gameObject.GetComponent<Collider2D>());
        //Destroy(gameObject.GetComponent<Collider2D>());
        //StartCoroutine("WaitToDie");
        

    }

    //IEnumerator WaitToDie()
    //{
    //    yield return new WaitForSeconds(1f);
    //    print(gameObject.name + " died.");
    //    Destroy(gameObject);
    //}

    private void TakeDamage(int damageTaken)
    {
        audioSource.PlayOneShot(audioClip, .6f);
        bounce.textMesh.text = damageTaken.ToString();
        health -= damageTaken;

        if (health <= 0)
        {
            Die();
        }
    }

    public int DealDamage()
    {
        //print(string.Format("{0} dealt {1} damage.", gameObject.name, damage));
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
