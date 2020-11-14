using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    HingeJoint2D hinge;
    int hingeCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            hingeCount = 3;
        }
    }

    void FixedUpdate()
    {

        hingeCount--;
        if (hingeCount>0)
        {
            hinge.useMotor=true;
        }
        else 
        {
            hinge.useMotor=false;
        }
    }
}
