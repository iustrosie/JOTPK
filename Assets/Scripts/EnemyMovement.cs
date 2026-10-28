using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Tutaj też można ulepszyć w sprawozdaniu żeby logika przeciwnika była lepsza (np nie uwzględnia obiektów blokujących)

    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _player;
    private Vector2 _moveDirection;
    private GameManager _gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = _player.transform.position;
        _moveDirection = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y).normalized;
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveDirection * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag($"Bullet"))
        {
            _rb.linearVelocity = Vector2.zero;
            _rb.bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Animator>().SetBool("Alive", false);
            Destroy(gameObject, 2);
        }   
    }
}
