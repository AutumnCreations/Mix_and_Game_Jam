﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float speed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] Transform towerPlacer;
    [SerializeField] Transform ballHolder;

    float horzInput;
    bool actionPress;
    bool firstRunHolding = false;

    [SerializeField]
    GameObject holding = null;

    BuildingPreviewer buildingPreviewer;
    CountCollisions countCollisions;

    void Start()
    {
        buildingPreviewer = FindObjectOfType<BuildingPreviewer>();
        buildingPreviewer.gameObject.SetActive(false);
        countCollisions = GetComponent<CountCollisions>();
    }

    void Update()
    {
        GetUserInput();
    }

    void FixedUpdate()
    {
        transform.position += transform.right * horzInput * speed * Time.fixedDeltaTime;

        if (holding)
        {
            HandleHolding();
        }
        else if (actionPress)
        {
            HandleGrab();
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

    private void HandleGrab()
    {
        GameObject closest = null;
        float distance = 999;

        //Loop through all objects the player is colliding with, and find the closest
        foreach (GameObject collidedObj in countCollisions.collisions)
        {

            if (collidedObj.CompareTag("buildingKit") || collidedObj.CompareTag("unthrownBall"))
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
            firstRunHolding = true;
        }
    }

    private void HandleHolding()
    {
        if (holding.CompareTag("buildingKit"))
        {
            if (firstRunHolding)
            {
                buildingPreviewer.gameObject.SetActive(true);
                buildingPreviewer.buildingToInstantiate = holding.GetComponent<BuildingKit>().towerToBuild;
                buildingPreviewer.SetBuildingSprite();
                firstRunHolding = false;
            }
            //buildingPreviewer.transform.position = new Vector3(Mathf.Round(objectPlacement.position.x * 2) / 2, Mathf.Round(objectPlacement.position.y * 2) / 2, -1);
            buildingPreviewer.transform.position = towerPlacer.position;
        }
        if (holding.CompareTag("unthrownBall") && firstRunHolding)
        {
            holding.transform.position = ballHolder.position;
            firstRunHolding = false;
        }

        if (actionPress)
        {
            holding.transform.SetParent(null);

            if (holding.CompareTag("unthrownBall"))
            {
                Instantiate(ballPrefab, ballHolder.position, Quaternion.identity);
                Destroy(holding);
            }

            if (holding.CompareTag("buildingKit"))
            {
                buildingPreviewer.gameObject.SetActive(false);
                Instantiate(holding.GetComponent<BuildingKit>().towerToBuild, buildingPreviewer.transform.position, Quaternion.identity);
                Destroy(holding);
            }
            holding = null;
        }
    }
}

