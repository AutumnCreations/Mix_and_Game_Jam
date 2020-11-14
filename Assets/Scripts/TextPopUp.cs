using TMPro;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private float fade = 1;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        fade -= Time.deltaTime;
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b,fade);
        transform.position += transform.up * Time.deltaTime;
        if (fade < 0)
        {
            Destroy(gameObject);
        }
    }
}
