using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    public float Speed = 0.05f;
    public bool moveLeft = true;
    public Transform groundDetect;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector2.left);
        // ������ ���, ������� �������, ����������� �� ��������� ��� ���
        // Raycast ��������� ��� ���������: �������, ������ ����� �������� ���; ���� �� ����� ���������; ����� ����)
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 1f);

        if (groundInfo.collider == false)
        {
            if (moveLeft)
            {   // ������������ ������, ������ rotation
                transform.eulerAngles = new Vector3(0,180,0);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;
            }
        }
    }
}
