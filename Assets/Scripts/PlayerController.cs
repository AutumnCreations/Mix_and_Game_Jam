using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Held Object")]
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject holding = null;

    [Header("Player Stats")]
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float runSpeed = 1.5f;

    private float horzInput;
    private bool actionPress;
    private float speed;

    CountCollisions countCollisions;

    void Start()
    {
        countCollisions = GetComponent<CountCollisions>();
        speed = walkSpeed;
    }

    void Update()
    {
        GetUserInput();
    }

    void FixedUpdate()
    {
        transform.position += transform.right * horzInput * speed * Time.fixedDeltaTime;

        if (actionPress)
        {
            if (holding)
            {
                //holding.transform.position = transform.position;
                if (actionPress)
                {
                    DropObject();
                }
            }
            else
            {
                GrabObject();
            }
        }
        actionPress = false;
    }

    private void GetUserInput()
    {
        horzInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            actionPress = true;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            speed = runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.RightShift))
        {
            speed = walkSpeed;
        }
    }

    private void GrabObject()
    {
        GameObject closest = null;
        float distance = 999;

        //Loop through all objects the player is colliding with, and find the closest
        foreach (GameObject collidedObj in countCollisions.collisions)
        {
            if (collidedObj.CompareTag("buildingPrefab") || collidedObj.CompareTag("unthrownBall"))
            {
                if (Vector2.Distance(transform.position, collidedObj.transform.position) < distance)
                {
                    distance = Vector2.Distance(transform.position, collidedObj.transform.position);
                    closest = collidedObj;
                }
            }
        }

        //grab hold of the closest object
        if (closest)
        {
            holding = closest;
            holding.transform.SetParent(transform);
        }
    }

    private void DropObject()
    {
        holding.transform.SetParent(null);

        if (holding.CompareTag("unthrownBall"))
        {
            Destroy(holding);
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
        holding = null;
    }
}