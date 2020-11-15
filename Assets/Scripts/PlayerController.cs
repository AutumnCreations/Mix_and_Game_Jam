using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Base playerBase;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject plotPrefab;
    [SerializeField] GameObject unthrownBallPrefab;
    [SerializeField] float speed;
    //[SerializeField] float walkSpeed;
    //[SerializeField] float runSpeed;
    [SerializeField] Transform towerPlacer;
    [SerializeField] Transform ballHolder;

    Animator animator;

    float horzInput;
    bool actionPress;
    bool firstRunHolding = false;

    [SerializeField]
    GameObject holding = null;

    BuildingPreviewer buildingPreviewer;
    CountCollisions countCollisions;
    BallCart ballCart;

    [SerializeField] public GameObject textPrefab;

    void Start()
    {
        ballCart = FindObjectOfType<BallCart>();
        buildingPreviewer = FindObjectOfType<BuildingPreviewer>();
        buildingPreviewer.gameObject.SetActive(false);
        countCollisions = GetComponent<CountCollisions>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetUserInput();
        HandleAnimation();
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * horzInput * speed * Time.fixedDeltaTime;

        Vector3 newBounds = new Vector3(Mathf.Clamp(transform.position.x, -4, 4), transform.position.y, transform.position.z);
        transform.position = newBounds;

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
        //if (Input.GetKeyDown(KeyCode.RightShift))
        //{
        //    speed = runSpeed;
        //}
        //else if (Input.GetKeyUp(KeyCode.RightShift))
        //{
        //    speed = walkSpeed;
        //}
    }

    private void HandleGrab()
    {
        GameObject closest = null;
        float distance = 999;

        //Loop through all objects the player is colliding with, and find the closest
        foreach (GameObject collidedObj in countCollisions.collisions)
        {

            if (collidedObj.CompareTag("shopSlot") || collidedObj.CompareTag("ballCart") || collidedObj.CompareTag("waveStart") )
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


            if (closest.CompareTag("shopSlot"))
            {
                var shopSlot = closest.GetComponent<ShopSlot>();
                if (!shopSlot.currentKit) { return; }
                //picking up a building kit or making another purchase from the store
                bool canAfford = playerBase.SpendGold(shopSlot.currentKit.cost);    //true if have enough money. automatically detracts cost.
                if (canAfford)
                {
                    holding = shopSlot.currentKit.gameObject;
                    holding.transform.SetParent(transform);
                    shopSlot.SellKit();
                    firstRunHolding = true;
                }
                else 
                {
                    GameObject x = Instantiate(textPrefab);
                    x.transform.position = transform.position;
                    x.GetComponentInChildren<TextMeshProUGUI>().text = "Not enough money!";
                }
            }
            else if (closest.CompareTag("ballCart") && ballCart.currentBalls > 0)
            {
                ballCart.UpdateBalls(-1);

                //picking up a ball or another holdable object
                holding = Instantiate(unthrownBallPrefab, transform);
                //holding.transform.SetParent(transform);
                firstRunHolding = true;
            }
            else if (closest.CompareTag("waveStart"))
            {
                
                FindObjectOfType<WaveManager>().StartWave();
                BuildingKit[] kits = FindObjectsOfType<BuildingKit>();
                foreach (BuildingKit kit in kits)
                {
                    Destroy(kit.gameObject);
                }
            }
            

        }
    }

    private void HandleHolding()
    {
        if (holding.CompareTag("buildingKit"))
        {
            if (firstRunHolding)
            {
                buildingPreviewer.buildingToInstantiate = holding.GetComponent<BuildingKit>().towerToBuild;
                buildingPreviewer.SetBuildingSprite();
                firstRunHolding = false;
            }

            //buildingPreviewer.transform.position = towerPlacer.position;

            GameObject obj = null;
            foreach (GameObject collidedObj in countCollisions.collisions)
            {
                if (collidedObj.CompareTag("Plot"))
                {
                    obj = collidedObj;
                    break;
                }
            }

            if (obj)
            {
                buildingPreviewer.transform.position = obj.transform.position;
                buildingPreviewer.gameObject.SetActive(true);

            }
            else
            {
                buildingPreviewer.gameObject.SetActive(false);
            }
        }
        else if (holding.CompareTag("unthrownBall"))
        {
            holding.transform.position = ballHolder.position;
            firstRunHolding = false;
        }

        if (actionPress)
        {
            if (holding.CompareTag("unthrownBall"))
            {
                GameObject closest = null;
                float distance = 999;
                bool thrownAlready = false;

                //Loop through all objects the player is colliding with, and find the closest
                foreach (GameObject collidedObj in countCollisions.collisions)
                {
                    if (collidedObj.CompareTag("buildingPrefab"))
                    {
                        if (Vector2.Distance(transform.position, collidedObj.transform.position) < distance)
                        {
                            distance = Vector2.Distance(transform.position, collidedObj.transform.position);
                            closest = collidedObj;
                        }
                    }
                }

                if (closest)
                {
                    Building building = closest.GetComponentInParent<Building>();
                    if (building)
                    {
                        if (building.specialBallPrefab)
                        {
                            thrownAlready = true;
                            Instantiate(building.specialBallPrefab, ballHolder.position, Quaternion.identity);
                            Destroy(holding);
                            //Destroy building
                            Instantiate(plotPrefab, building.transform.position, Quaternion.identity);
                            Destroy(building.gameObject);
                            
                        }
                    }
                }




                if (!thrownAlready)
                {
                    Instantiate(ballPrefab, ballHolder.position, Quaternion.identity);
                    Destroy(holding);
                }

            }

            if (holding.CompareTag("buildingKit"))
            {
                List<GameObject> buildingPreviewerCollisions = buildingPreviewer.GetComponent<CountCollisions>().collisions;
                GameObject obj = null;

                foreach (GameObject collidedObj in buildingPreviewerCollisions)
                {
                    if (collidedObj.CompareTag("Plot"))
                    {
                        obj = collidedObj;
                        break;
                    }
                }

                if (obj)
                {

                    holding.transform.SetParent(null);
                    buildingPreviewer.gameObject.SetActive(false);
                    Instantiate(holding.GetComponent<BuildingKit>().towerToBuild, buildingPreviewer.transform.position, Quaternion.identity);
                    Destroy(obj);
                    Destroy(holding.gameObject);
                    holding = null;
                }


                else
                {
                    print("I Cannot build here you dummy!");
                }

            }

        }
    }

    void HandleAnimation()
    {
        if (horzInput > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.Play("playerWalk");
        }
        else if (horzInput < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.Play("playerWalk");
        }
        else
        {
            animator.Play("playerIdle");
        }
    }
}

