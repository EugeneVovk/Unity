using System.Collections;
using UnityEngine;

public class AdvancedAirPatrol : MonoBehaviour
{
    public Transform[] Points;
    public float Speed = 2f;
    public float WaitTime = 2f;
    private bool _canGo = true;
    private int _index = 1;

    void Start()
    {
        gameObject.transform.position = new Vector3(Points[0].position.x, Points[0].position.y,transform.position.z);
    }

    void Update()
    {
        if (_canGo)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[_index].position, Speed * Time.deltaTime);
        }

        if (transform.position == Points[_index].position)
        {
            if (_index < Points.Length - 1)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }

            _canGo = false;
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(WaitTime);
        
        _canGo = true;
    }
}
