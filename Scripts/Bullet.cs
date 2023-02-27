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

    // после исчезновения первого объекта, остальные становятся неактивными
    // решение - создать папку Prefabs, поместить туда снаряд и уже из этой папки добавить его в Bomber
    // папка Prefabs - это ресурсы самой игры
    IEnumerator SetDisabled()
    {
        yield return new WaitForSeconds(_timeToDisable);
        // скрываем объект
        gameObject.SetActive(false);
    }

    // метод, который скрывает снаряд после попадания (при столкновении)
    private void OnCollisionEnter2D(Collision2D bullet)
    {
        gameObject.SetActive(false);
        StopCoroutine(SetDisabled());
    }
}
