using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public AudioClip dropHuman;

    GameManager gm;
    AudioSource audioSource;




    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            audioSource.PlayOneShot(dropHuman);
            gm.ChangeLives(-1);
            gm.CheckLoseOrNot();
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        
    }
}
