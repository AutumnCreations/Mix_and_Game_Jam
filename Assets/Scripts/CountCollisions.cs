using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CountCollisions : MonoBehaviour
{


    [SerializeField] bool solidOnly=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> removes = new List<GameObject>();

        
        foreach ( GameObject obj in collisions )
        {
            if (!obj)
                removes.Add(obj);
        }

        foreach (GameObject obj in removes)
            collisions.Remove(obj);
        
    }

    public List<GameObject> collisions;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger && solidOnly) 
            return;

        if (!collisions.Contains(col.gameObject))
        {
            collisions.Add(col.gameObject);
            
        }
            
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (collisions.Contains(col.gameObject))
            collisions.Remove(col.gameObject);
    }
}
