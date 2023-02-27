using UnityEngine;

public class Water : MonoBehaviour
{
    private float _timer = 0f;
    private float _timeHit = 0f;

    void Start()
    {

    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 2f)
        {
            _timer = 0;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (_timer >= 1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().InWater = true;
            _timeHit += Time.deltaTime;

            // нахождение в воде более 10секунд, отнимется жизнь
            if (_timeHit > 10f)
            {
                collision.GetComponent<Player>().RecountHealth(-1);
                ResetTimerHit();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().InWater = false;
            ResetTimerHit();
        }
    }

    private void ResetTimerHit()
    {
        _timer = 0f;
    }
}
