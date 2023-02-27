
using UnityEngine;

public class CameraWithBug : MonoBehaviour
{
    private float _speed = 3f;
    public Transform Target;

    void Start()
    {
        transform.position = new Vector3(Target.transform.position.x,
                                         Target.transform.position.y,
                                         Target.transform.position.z);
    }

    // делаем плавное следование камеры за игроком(объектом target)
    // метод Lerp() плавно уменьшае расстояние между объектами
    // _speed - скорость приближения камеры
    void Update()
    {
        Vector3 position = Target.position;
        position.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
    }
}
