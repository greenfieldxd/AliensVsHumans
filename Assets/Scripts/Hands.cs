using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public float minX; // Максимальное и минимальное X координат платформы
    public float maxX;
    public bool transformHands;

    



    void Start()
    {
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

   
}
