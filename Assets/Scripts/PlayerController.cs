using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;    

    float horzInput;

    bool actionPress;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (actionPress)
        {
            Instantiate( ballPrefab, transform.position, Quaternion.identity );
        }


        actionPress=false;
    }
}