using System.Collections;
using UnityEngine;

public class AirPatrol : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;
    public float Speed = 1.0f;
    public float WaitTime = 0.5f;
    private bool _canGo = true;

    void Start()
    {
        gameObject.transform.position = new Vector3(Point1.position.x, Point1.position.y, transform.position.z);
    }

    void Update()
    {
        if (_canGo)
        {
            // принимает 3 аргумента: текущая позиция, куда двигаться и скорость движения
            transform.position = Vector3.MoveTowards(transform.position, Point1.position, Speed * Time.deltaTime);
        }

        if (transform.position == Point1.position)
        {
            (Point1, Point2) = (Point2, Point1);
            _canGo = false;
            StartCoroutine(Waiting());
        }
    }

    // чтобы летающий объект зависал вверху и внизу, мы прибегаем к корутине
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(WaitTime);

        if (transform.rotation.y == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        _canGo = true;
    }
}
