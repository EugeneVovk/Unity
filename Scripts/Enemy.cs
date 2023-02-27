using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _isHit = true;

    // методы обработки столкновений (соприкосновение колайдеров)
    // Enter - когда объекты сталкиваются
    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player") && _isHit)
        {
            print("Произошло столкновение");
            print("Минус одна жизнь");
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

    // Stay  - когда объекты соприкасаются
    private void OnCollisionStay2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            print("Stay");
        }
    }

    // Exit  - когда соприкосновение прекращается
    private void OnCollisionExit2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            print("Объекты разошлись");
        }
    }
    */
}
