using UnityEngine;

public class Ball : MonoBehaviour
{
    [Tooltip("Minimum force to add to the ball when colliding with a peg")]
    [SerializeField] float randomOffsetMin = .01f;
    [Tooltip("Maximum force to add to the ball when colliding with a peg")]
    [SerializeField] float randomOffsetMax = .1f;
    [SerializeField] Vector2 startingForce;
    [SerializeField] public int damage = 1;

    [Header("Ball Variants")]
    [SerializeField] bool isMultiBall = false;
    [SerializeField] bool isFireBall = false;

    bool firstHit = true;

    //Force to add to the ball when colliding with a peg
    float xOffset;
    Rigidbody2D ballBody;

    Collider2D lastPeg;

     AudioSource audioSource;

    [SerializeField] AudioClip audioClip;

    void Start()
    {
        ballBody = GetComponent<Rigidbody2D>();
        ballBody.AddForce(startingForce);
        
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        audioSource.PlayOneShot(audioClip, .3f);

        if (collision.gameObject.CompareTag("Peg") || collision.gameObject.CompareTag("Enemy"))
        {
            HandleMultiBall();

            if (lastPeg == null || lastPeg != collision.collider)
            {
                xOffset = Random.Range(randomOffsetMin, randomOffsetMax);
                //Returns xOffset randomly as positive or negative
                xOffset *= Random.Range(0, 2) * 2 - 1;
            }
            ballBody.AddForce(new Vector2(xOffset, 0));

            lastPeg = collision.collider;
        }
    }

    private void HandleMultiBall()
    {
        if (firstHit && isMultiBall)
        {
            var ball1 = Instantiate(gameObject, transform.position, Quaternion.identity);
            ball1.GetComponent<Ball>().isMultiBall = false;
            var ball2 = Instantiate(gameObject, transform.position, Quaternion.identity);
            ball2.GetComponent<Ball>().isMultiBall = false;
            firstHit = false;
        }
    }
}
