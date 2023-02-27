using System.Collections;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Shoot;
    public float TimeShoot = 3f;

    void Start()
    {
        // позиция выстрела будеть на 1 позицию ниже, чем у источника
        Shoot.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        StartCoroutine(Shooting());
    }

    void Update()
    {
        
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(TimeShoot);
        // создаём объект снаряд
        Instantiate(Bullet, Shoot.transform.position, transform.rotation);

        StartCoroutine(Shooting());
    }
}
