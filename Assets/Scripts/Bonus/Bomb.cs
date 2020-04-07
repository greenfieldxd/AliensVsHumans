using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip bombClip;
    public GameObject Boom;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hands"))
        {
          

            Ufo[] UfoObjects = FindObjectsOfType<Ufo>();
            audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(bombClip);

            foreach (Ufo Ufo in UfoObjects)
            {
                GameObject newObject = Instantiate(Boom, Ufo.transform.position, Quaternion.identity);
                Destroy(newObject.gameObject, 2f);
                Destroy(Ufo.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
