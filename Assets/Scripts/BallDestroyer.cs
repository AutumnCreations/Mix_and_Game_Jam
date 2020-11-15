using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    BallCart ballCart;

    private void Start()
    {
        ballCart = FindObjectOfType<BallCart>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);

            StartCoroutine("RespawnBall");
        }
    }

    private IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(1f);
        var ballsInWorld = FindObjectsOfType<Ball>();
        print(ballsInWorld.Length);
        if (ballsInWorld.Length < ballCart.maxBalls)
        {
            ballCart.UpdateBalls(1);
        }
    }
}
