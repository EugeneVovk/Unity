using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 4f;
    private float _timeToDisable = 2f;

    void Start()
    {
        StartCoroutine(SetDisabled());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.down);
    }

    // ����� ������������ ������� �������, ��������� ���������� �����������
    // ������� - ������� ����� Prefabs, ��������� ���� ������ � ��� �� ���� ����� �������� ��� � Bomber
    // ����� Prefabs - ��� ������� ����� ����
    IEnumerator SetDisabled()
    {
        yield return new WaitForSeconds(_timeToDisable);
        // �������� ������
        gameObject.SetActive(false);
    }

    // �����, ������� �������� ������ ����� ��������� (��� ������������)
    private void OnCollisionEnter2D(Collision2D bullet)
    {
        gameObject.SetActive(false);
        StopCoroutine(SetDisabled());
    }
}
