using System;
using System.Collections;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    public float Speed = 1f;
    private bool _isWait = false;
    private bool _isHidden = false;
    public float WaiteTime = 4f;
    public Transform Point;

    void Start()
    {
        // жук должен вылезать из земли на одну клетку
        Point.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }

    void Update()
    {
        if (!_isWait)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point.position, Speed * Time.deltaTime);
        }

        if (transform.position == Point.position)
        {
            if (_isHidden)
            {
                Point.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                _isHidden = false;
            }
            else
            {
                Point.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                _isHidden = true;
            }

            _isWait = true;
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(WaiteTime);
        _isWait = false;
    }
}
