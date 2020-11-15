using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public bool moveLeft=false;

    [SerializeField] float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
            transform.position += transform.right*-1*Time.deltaTime*speed;
        else 
            transform.position += transform.right*1*Time.deltaTime*speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
    }
}
