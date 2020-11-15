using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Animator animator;

    AudioSource audioSource;

    [SerializeField] AudioClip audioClip;

    float soundTimeOut = 0;

    [SerializeField]
    float audioScale = 1;

    private void Start()
    {
        
        animator = GetComponent<Animator>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            animator.SetTrigger("Hit");
        }
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip, audioScale);
    }
}
