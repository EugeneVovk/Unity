using System.Collections;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Shoot;
    public float TimeShoot = 3f;

    void Start()
    {
        // ������� �������� ������ �� 1 ������� ����, ��� � ���������
        Shoot.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        StartCoroutine(Shooting());
    }

    void Update()
    {
        
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(TimeShoot);
        // ������ ������ ������
        Instantiate(Bullet, Shoot.transform.position, transform.rotation);

        StartCoroutine(Shooting());
    }
}
