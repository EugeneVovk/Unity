using System;
using System.Collections;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    // метод работает при столкновении с каким-то колайдером
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Player"))
        {
            // при столкновении объект отскакиевает
            enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 8f, ForceMode2D.Impulse);
            gameObject.GetComponentInParent<Enemy>().StartDeath();
        }
    }
}
