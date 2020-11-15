using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    //[SerializeField] float speed = 0f;
    //private HingeJoint2D hinge;
    //private JointMotor2D motor;
    //int hingeCount = 3;

    [SerializeField] float rotationSpeed = .5f;
    [SerializeField] float idleZ = -16f;
    [SerializeField] float activeZ = 20f;
    [SerializeField] Vector2 power = new Vector2(0, 100f);
    Quaternion rotation;

    void Start()
    {
        //hinge = GetComponent<HingeJoint2D>();
        //motor = hinge.motor;
        Vector3 idleRotation = new Vector3(0, 0, idleZ);
        Vector3 activeRotation = new Vector3(0, 0, activeZ);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Return))
        {
            rotation = Quaternion.Euler(0, 0, activeZ);
        }
        else
        {
            rotation = Quaternion.Euler(0, 0, idleZ);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed);
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(power);
            }
        }
    }

    void FixedUpdate()
    {
        //if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Return))
        //{
        //    //hingeCount = 3;
        //    motor.motorSpeed = speed;
        //    hinge.motor = motor;
        //}
        //else
        //{
        //    motor.motorSpeed = -speed;
        //    hinge.motor = motor;
        //}
        //hingeCount--;
        //if (hingeCount > 0)
        //{
        //    hinge.useMotor = true;
        //}
        //else
        //{
        //    hinge.useMotor = false;
        //}
    }
}
