using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public int points = 1;
    public AudioClip humanClip;


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
            audioSource.PlayOneShot(humanClip);
            gm.AddScore(points);
            Destroy(gameObject);
        }
        
    }
}
