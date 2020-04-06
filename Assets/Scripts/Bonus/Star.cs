using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public AudioClip starClip;

    GameManager gm;
    AudioSource audioSource;


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();   
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hands"))
        {
            audioSource.PlayOneShot(starClip);
            gm.AddScore(20);
            Destroy(gameObject);
        }
    }
}
