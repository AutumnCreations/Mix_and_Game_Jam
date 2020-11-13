using UnityEngine;

public class Ball : MonoBehaviour
{
    [Tooltip("Minimum force to add to the ball when colliding with a peg")]
    [SerializeField] float randomOffsetMin = .01f;
    [Tooltip("Maximum force to add to the ball when colliding with a peg")]
    [SerializeField] float randomOffsetMax = .1f;

    //Force to add to the ball when colliding with a peg
    float xOffset;
    Rigidbody2D ballBody;

    Collider2D lastPeg;

    void Start()
    {
        ballBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Peg"))
        {
            if (lastPeg == null || lastPeg != collision.collider)
            {
                xOffset = Random.Range(randomOffsetMin, randomOffsetMax);
                //Returns xOffset randomly as positive or negative
                xOffset *= Random.Range(0, 2) * 2 - 1;
            }
            ballBody.AddForce(new Vector2(xOffset, 0));

            lastPeg = collision.collider;
        }

        print(xOffset);
    }

}
