using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public float minX; // Максимальное и минимальное X координат платформы
    public float maxX;
    public int points = 1;
    public bool transformHands;

    GameManager gm;



    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        transformHands = true;
    }

    void Update()
    {
        HandsTransform();
    }

    private void HandsTransform()
    {
        if (transformHands)
        {
            Vector3 mousePos = Input.mousePosition;// позиция мыши в координатах камеры
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos); // позиция мыши в координатах мира
                                                                              //Debug.Log("mousePos: " + mousePos + ", mouseWorldPos: " + mouseWorldPos);

            float xHands = mouseWorldPos.x;// значение x координат мыши
            float clampedHandsX = Mathf.Clamp(xHands, minX, maxX); // обрезаем координаты платформы по x до нужных нам значений
            float yHands = transform.position.y;

            transform.position = new Vector3(clampedHandsX, yHands, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            gm.AddScore(points);
            gm.ChangeSpeedObjects(25, 2);
            gm.ChangeSpeedObjects(50, 3);
            gm.ChangeSpeedObjects(75, 4);
            gm.ChangeSpeedObjects(100, 6);
            gm.ChangeSpeedObjects(125, 8);
            Destroy(collision.gameObject); 
        }
        if (collision.gameObject.CompareTag("Ufo"))
        {
            gm.ChangeLives(-1);
            Destroy(collision.gameObject);
            gm.CheckLoseOrNot();
        }
    }
}
