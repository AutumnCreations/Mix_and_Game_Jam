using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveText : MonoBehaviour
{

    Vector3 start;
    TextMeshProUGUI textMeshPro;

    float fade=1;

    bool show = true;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void Display(int number)
    {
        if (number != 999)
            textMeshPro.text = "Wave " + (number+1) + "!";
        else 
            textMeshPro.text = "Final Wave!";
        transform.position = start;
        fade = 1;
        textMeshPro.color = new Color(1,0,0,1);
        show = true;
        textMeshPro.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            fade -= Time.deltaTime;
            transform.position += transform.up * Time.deltaTime;
            textMeshPro.color = new Color(1,0,0,fade);
            if (fade <= 0)
            {
                show = false;
                textMeshPro.enabled = false;
            }
        }
        

    }
}
