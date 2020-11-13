using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;    

    float horzInput;

    bool actionPress;

    [SerializeField]
    GameObject holding = null;

    CountCollisions countCollisions;

    // Start is called before the first frame update
    void Start()
    {
        countCollisions = GetComponent<CountCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        horzInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1"))
        {
            actionPress=true;
        }
    }

    void FixedUpdate()
    {
        transform.position += transform.right * horzInput * Time.fixedDeltaTime;

        

        if (holding)
        {
            //holding.transform.position = transform.position;
            if (actionPress)
            {
                
                holding.transform.SetParent(null);
                
                if (holding.CompareTag("unthrownBall"))
                {
                    Destroy(holding);
                    Instantiate( ballPrefab, transform.position, Quaternion.identity );
                    
                }
                
                
                holding=null;

              
            }
        }
        else 
        {
            if (actionPress)
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

            
        }


        actionPress=false;
    }
}