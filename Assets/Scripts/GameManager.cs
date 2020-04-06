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
    public GameObject[] bonuses;

    Hands hands;

    int score; //game score
    bool createObjects;
    bool pauseActive;


    private void Start()
    {
        hands = FindObjectOfType<Hands>(); 

        textScore.text = "Score: 0";
        textLives.text = "Lives: " + lives;
        createObjects = true;
        SetGravityScale();// make gravity scale 1
        pauseActive = false;

        InvokeRepeating("CreateObject", 1, 0.8f);
        InvokeRepeating("CreateBonus", 8, 8);
        InvokeRepeating("ChangeSpeedObjects", 10, 10);

    }


    public void PauseGame() //Пауза в игре
    {
        Hands hands = FindObjectOfType<Hands>();

        if (pauseActive)
        {
            Time.timeScale = 1;
            //turn off Pause                
            pauseActive = false;
            hands.transformHands = true; ; //turn on the movement
        }
        else
        {
            //turn on Pause
            Time.timeScale = 0;
            pauseActive = true;
            hands.transformHands = false;//turn off the movement
            
        }
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

    void CreateBonus()
    {
        int chance = Random.Range(0, 2);

        if (createObjects == true && chance == 0)
        {
            int indexObject = Random.Range(0, bonuses.Length);
            float xPosition = Random.Range(-9, 9);
            Vector3 newPosition = new Vector3(xPosition, transform.position.y, transform.position.z);
            Instantiate(bonuses[indexObject], newPosition, Quaternion.identity);
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


        //return gravity scale to one in each element
        SetGravityScale();

        createObjects = true;
        hands.transformHands = true;
    }

    private void SetGravityScale()
    {
        foreach (GameObject element in objects)
        {
            Rigidbody2D rb = element.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1;
        }

        foreach (GameObject element in bonuses)
        {
            Rigidbody2D rb = element.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1;
        }
    }

    public void ChangeSpeedObjects()
    {
        
        foreach (GameObject element in objects)
        {
            Rigidbody2D rb = element.GetComponent<Rigidbody2D>();
            rb.gravityScale = rb.gravityScale + 1;
        }

        foreach (GameObject element in bonuses)
        {
            Rigidbody2D rb = element.GetComponent<Rigidbody2D>();
            rb.gravityScale = rb.gravityScale + 1;
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

   


