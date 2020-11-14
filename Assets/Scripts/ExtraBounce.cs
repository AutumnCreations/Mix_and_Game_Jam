using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBounce : MonoBehaviour
{

    [SerializeField]
    GameObject textPrefab;

    [SerializeField]
    float forceFactor = 5000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other) {

     
     if (other.gameObject.CompareTag("Ball"))
     {
        Vector2 force = transform.position - other.transform.position;
        force.Normalize();
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(force * forceFactor);
        GameObject x = Instantiate(textPrefab);
        x.transform.position = transform.position;
        x.transform.SetParent( FindObjectOfType<Canvas>().gameObject.transform );
     }
     
 }
}
