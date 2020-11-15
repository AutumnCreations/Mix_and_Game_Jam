using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    //[SerializeField] float speed = 0f;
    //private HingeJoint2D hinge;
    //private JointMotor2D motor;
    //int hingeCount = 3;

    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] float idleZ = -16f;
    [SerializeField] float activeZ = 20f;
    //[SerializeField] Vector2 power = new Vector2(0, 100f);

    [SerializeField] float power = 50;
    float rotation;

    Rigidbody2D rigidbody;

     AudioSource audioSource;

    [SerializeField] AudioClip audioClip;

    void Start()
    {
        //hinge = GetComponent<HingeJoint2D>();
        //motor = hinge.motor;
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Vector2 force = collision.contacts[0].point - new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
                force.Normalize();
                var ball = collision.gameObject.GetComponent<Rigidbody2D>();
                ball.AddForce(force * Vector2.up * power + (ball.velocity * -1));
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetButton("Fire2"))
        {
            if (rotation == idleZ)
                 audioSource.PlayOneShot(audioClip);
            rotation = activeZ;
        }
        else
        {
            rotation = idleZ;
        }
        

    }

    void FixedUpdate()
    {
        float myRotation = Mathf.Lerp(rigidbody.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
        rigidbody.MoveRotation(myRotation);
    }
}
