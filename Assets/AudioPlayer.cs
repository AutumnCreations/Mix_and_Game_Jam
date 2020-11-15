using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SingletonSetup();
    }

   private void SingletonSetup()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
            
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    
}
