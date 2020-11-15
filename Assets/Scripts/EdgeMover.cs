using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMover : MonoBehaviour
{

    Vector3 startPosition;
    [SerializeField] Transform otherSpot;
    [SerializeField] float speed;

    int dir = -1;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.position = transform.position += Vector3.up*dir * Time.fixedDeltaTime * speed;
        if (dir < 0 && transform.position.y < otherSpot.transform.position.y)
        {
            dir = 1;
        }
        if (dir > 0 && transform.position.y > startPosition.y)
        {
            dir = -1;
        }
    }
}
