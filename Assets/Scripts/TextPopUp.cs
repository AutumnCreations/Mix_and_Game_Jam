using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour
{
    Text text;
    float fade = 1;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        fade -= Time.deltaTime;
        text.color = new Color(text.color.r, text.color.g, text.color.b,fade);
        transform.position += transform.up * Time.deltaTime;
        if (fade < 0)
        {
            Destroy(gameObject);
        }
    }
}
