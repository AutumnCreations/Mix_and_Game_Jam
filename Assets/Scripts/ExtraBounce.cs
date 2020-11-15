using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBounce : MonoBehaviour
{
    [SerializeField] public GameObject textPrefab;
    [SerializeField] float forceFactor = 5000;

    [HideInInspector]
    public TextMeshProUGUI textMesh;

    Animator animator;

    private void Start()
    {
        if (textPrefab)
        {
            textMesh = textPrefab.GetComponentInChildren<TextMeshProUGUI>();
        }
        animator = GetComponent<Animator>();
    }



    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (animator)
            {
                animator.Play("Bounce");
            }
            Vector2 force = transform.position - other.transform.position;
            force.Normalize();
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(force * forceFactor);
            if (textPrefab)
            {
                //GameObject x = Instantiate(textPrefab);
                //x.transform.position = transform.position;
            }
        }

    }
}
