using TMPro;
using UnityEngine;

public class ExtraBounce : MonoBehaviour
{
    [SerializeField] public GameObject textPrefab;
    [SerializeField] float forceFactor = 5000;

    [HideInInspector]
    public TextMeshProUGUI textMesh;

    private void Start()
    {
        if (textPrefab)
        {
            textMesh = textPrefab.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Vector2 force = transform.position - other.transform.position;
            force.Normalize();
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(force * forceFactor);
            if (textPrefab)
            {
                GameObject x = Instantiate(textPrefab);
                x.transform.position = transform.position;
                //x.transform.SetParent(FindObjectOfType<Canvas>().gameObject.transform);
            }
        }

    }
}
