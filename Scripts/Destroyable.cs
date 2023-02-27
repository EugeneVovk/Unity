using System;
using System.Collections;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    // ����� �������� ��� ������������ � �����-�� ����������
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Player"))
        {
            // ��� ������������ ������ ������������
            enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 8f, ForceMode2D.Impulse);
            gameObject.GetComponentInParent<Enemy>().StartDeath();
        }
    }
}
