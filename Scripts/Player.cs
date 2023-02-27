using System.Collections;
using UnityEngine;
/**
 * ����� ���� �������� �� ��������, ���������� ��������
 */

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed;
    public float jumpHeight;
    public Transform groundCheck;
    private bool _isGrounded;
    private Animator _animator;
    private int _currentHealth;
    private int _maxHealth = 3;
    private bool _isHit = false;
    public Main Main;
    public bool IsKey = false;
    private bool _canTeleport = true;
    public bool InWater = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentHealth = _maxHealth;
    }

    // ��� ��� ��������(���������) ������� �����
    void Update()
    {
        if (InWater)
        {
            _animator.SetInteger("state", 4);
            _isGrounded = false;

            if (Input.GetAxis("Horizontal") != 0)
            {
                Flip();
            }
        }
        else
        {
            CheckGround();

            if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            }

            if (_isGrounded && Input.GetAxis("Horizontal") == 0)
            {
                _animator.SetInteger("state", 1);
            }
            else
            {
                Flip();

                if (_isGrounded)
                {
                    _animator.SetInteger("state", 2);
                }
            }
        }
    }

    // ������ ������
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rigidbody2D.velocity.y);

        //if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        //{
        //    _rigidbody2D.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        //}
    }

    // ������� ������ � ������� ��������
    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // ��������� ���� �� �����(��� ������ ��������� ��� ������ ������)
    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        _isGrounded = colliders.Length > 1;

        if (!_isGrounded)
        {
            _animator.SetInteger("state", 3);
        }
    }

    // ����� ��������� ������      
    public void RecountHealth(int deltaHealth)
    {
        _currentHealth += deltaHealth;
        print($"�������� ������: {_currentHealth}");

        if (deltaHealth < 0)
        {
            StopCoroutine(OnHit());
            _isHit = true;
            StartCoroutine(OnHit());
        }

        if (_currentHealth <= 0)
        {
            print("GAME OVER"); // ������ ���������� ���������(����� ������)
            GetComponent<CapsuleCollider2D>().enabled = false;

            Invoke("Lose", 1f); // ����� � ���������� ������� (1���)
        }
    }

    // �����, ������� ���������� ������ ���� ������, ��������� � ��������
    // �������� - ���� ����, ������� �������� ����������, ����������� � ������� ���������
    IEnumerator OnHit()
    {
        if (_isHit)
        {
            GetComponent<SpriteRenderer>().color =
                new Color(255f, GetComponent<SpriteRenderer>().color.g - 0.06f,
                                GetComponent<SpriteRenderer>().color.b - 0.06f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color =
                new Color(255f, GetComponent<SpriteRenderer>().color.g + 0.06f,
                                GetComponent<SpriteRenderer>().color.b + 0.06f);
        }

        if (GetComponent<SpriteRenderer>().color.g == 255f)
        {
            StopCoroutine(OnHit());
        }

        if (GetComponent<SpriteRenderer>().color.g <= 0)
        {
            _isHit = false;
        }

        // ��� ����� ������� �����, �� ����� (1���/50������) * 3 = 0,06(������ ��������)
        yield return new WaitForSeconds(0.06f);
        StartCoroutine(OnHit());
    }

    void Lose()
    {
        Main.GetComponent<Main>().Lose();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            IsKey = true;
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            if (collision.gameObject.GetComponent<Door>().IsOpen && _canTeleport)
            {
                collision.gameObject.GetComponent<Door>().Teleport(gameObject);
                _canTeleport = false;

                StartCoroutine(TelepertWait());
            }
            else if (IsKey)
            {
                collision.gameObject.GetComponent<Door>().Unlock();
                //����� ����� �������, �� ����� �����������������
            }
        }
    }

    private IEnumerator TelepertWait()
    {
        yield return new WaitForSeconds(1f);
        _canTeleport = true;
    }
}
