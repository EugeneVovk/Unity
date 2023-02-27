using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = _player.position.x;
        position.y = _player.position.y;

        transform.position = position;
    }
}
