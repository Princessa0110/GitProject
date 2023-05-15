using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Target"))
        {
            Destroy(gameObject); //уничтажаем пулю при столкновкнии
            Destroy(collision.gameObject);
        }
    }
}
