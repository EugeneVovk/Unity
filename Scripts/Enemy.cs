using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _isHit = true;

    // ������ ��������� ������������ (��������������� ����������)
    // Enter - ����� ������� ������������
    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player") && _isHit)
        {
            print("��������� ������������");
            print("����� ���� �����");
            player.gameObject.GetComponent<Player>().RecountHealth(-1);
            player.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(transform.up * 8f, ForceMode2D.Impulse);
        }
    }

    public IEnumerator Death()
    {
        _isHit = false;

        GetComponent<Animator>().SetBool("dead", true);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<Collider2D>().enabled = false;
        transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(4f);

        Destroy(gameObject);
    }

    public void StartDeath()
    {
        StartCoroutine(Death());
    }

    /*

    // Stay  - ����� ������� �������������
    private void OnCollisionStay2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            print("Stay");
        }
    }

    // Exit  - ����� ��������������� ������������
    private void OnCollisionExit2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            print("������� ���������");
        }
    }
    */
}
