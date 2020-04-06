using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip bombClip;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hands"))
        {
            Ufo[] UfoObjects = FindObjectsOfType<Ufo>();
            audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(bombClip);

            foreach (Ufo Ufo in UfoObjects) { Destroy(Ufo.gameObject); }
            Destroy(gameObject);
        }
    }
}
