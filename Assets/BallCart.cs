using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCart : MonoBehaviour
{
    [SerializeField] GameObject balls1;
    [SerializeField] GameObject balls2;
    [SerializeField] GameObject balls3;

    [HideInInspector]
    public int maxBalls = 3;
    [HideInInspector]
    public int currentBalls = 3;

    void Start()
    {
        balls1.SetActive(false);
        balls2.SetActive(false);
    }

    private void Update()
    {
        //var ballsInWorld = FindObjectsOfType<Ball>();
        //if (ballsInWorld.Length < maxBalls)
        //{
        //    UpdateBalls(maxBalls - ballsInWorld.Length);
        //}
    }

    private void DeactivateBallSprites()
    {
        balls1.SetActive(false);
        balls2.SetActive(false);
        balls3.SetActive(false);
    }

    public void UpdateBalls(int ballAmount)
    {
        currentBalls += ballAmount;
        DeactivateBallSprites();

        switch (currentBalls)
        {
            case 1:
                balls1.SetActive(true);
                break;
            case 2:
                balls2.SetActive(true);
                break;
            case 3:
                balls3.SetActive(true);
                break;
            default:
                DeactivateBallSprites();
                break;
        }
    }
}
