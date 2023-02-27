using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen = false;
    public Transform door;
    public Sprite middle;
    public Sprite top;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Unlock()
    {
        IsOpen = true;
        GetComponent<SpriteRenderer>().sprite = middle;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = top;
    }

    // ����� ���������, � ���������� ������, ������� �� ����� ���������������
    public void Teleport(GameObject player)
    {
        // ������� ������� ����������� ������� ����� � ��������� ��� z
        player.transform.position =
            new Vector3(door.position.x, door.position.y, player.transform.position.z);
    }
}
