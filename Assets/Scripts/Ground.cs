using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    GameManager gm;


    void Start()
    {
        gm = FindObjectOfType<GameManager>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            gm.ChangeLives(-1);
            Destroy(collision.gameObject);
            gm.CheckLoseOrNot();
        }
        if (collision.gameObject.CompareTag("Ufo"))
        {
            Destroy(collision.gameObject);
        }
    }
}
