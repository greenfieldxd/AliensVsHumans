using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives = 3; //game lives

    public Text textScore; //text score on scene
    public Text textLives;
    public Text loseText;
    public Image loseImage;
    public GameObject[] objects;

    Hands hands;

    int score; //game score
    bool createObjects;


    private void Start()
    {
        hands = FindObjectOfType<Hands>(); 

        textScore.text = "Score: 0";
        textLives.text = "Lives: " + lives;
        createObjects = true;
        ChangeSpeedObjects(0, 1);

        InvokeRepeating("CreateObject", 2, 1);

    }



    void CreateObject()
    {
        if (createObjects == true)
        {
            int indexObject = Random.Range(0, objects.Length);
            float xPosition = Random.Range(-9, 9);
            Vector3 newPosition = new Vector3(xPosition, transform.position.y, transform.position.z);
            Instantiate(objects[indexObject], newPosition, Quaternion.identity);
        }
    }

    public void CheckLoseOrNot()
    {
        if (lives == 0)
        {
            loseImage.gameObject.SetActive(true);
            loseText.text = "You lost, the result was: " + score + ".";
            createObjects = false;
            hands.transformHands = false;
        }

    }

    public void PlayAgain()
    {
        loseImage.gameObject.SetActive(false);
        lives = 3;
        textLives.text = "Lives: " + lives;

        score = 0;
        textScore.text = "Score: " + score;
        ChangeSpeedObjects(0, 1);

        createObjects = true;
        hands.transformHands = true;
    }

    public void ChangeSpeedObjects(int scoreNumber, int scaleNumber)
    {
        if (score == scoreNumber)
        {
            foreach (GameObject element in objects)
            {
                Rigidbody2D rb = element.GetComponent<Rigidbody2D>();
                rb.gravityScale = scaleNumber;
            }
        }
    }

    public void AddScore(int number)
    {
        score += number;
        textScore.text = "Score: " + score;
    }

    public void ChangeLives(int number)
    {
        lives += number;
        textLives.text = "Lives: " + lives;
    }

}
