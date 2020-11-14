using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotater : MonoBehaviour
{
    [SerializeField] float rotationAmount = 10;
    [SerializeField] float rotationTimeIncrement = .5f;

    float currentRotation = 0;
    float currentTime = 0;

    void Update()
    {
        if (currentTime > rotationTimeIncrement)
        {
            currentRotation += .1f;
            transform.Rotate(0, 0, currentRotation);

            if (currentRotation == rotationAmount)
            {
                rotationAmount *= -1;
                currentRotation *= -1;
                currentTime = 0;
            }
        }
        currentTime += Time.deltaTime;
    }
}
