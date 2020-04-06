using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{

    public AudioClip ufoClip;

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
            audioSource.PlayOneShot(ufoClip);
            gm.ChangeLives(-1);
            gm.CheckLoseOrNot();
            Destroy(gameObject);
        }
    }
}
