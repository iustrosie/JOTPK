using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    private string _currentState;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _sprites;

    /*
    * 0 - player idle
    * 1 - player shooting down
    * 2 - player shooting up
    * 3 - player shooting left
    * 4 - player shooting right
    */



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void OnMove(InputValue value)
    {
        Vector2 move = value.Get<Vector2>();

        if (move != Vector2.zero)
            ChangeAnimation("Player_walk");
        else
            ChangeAnimation("Player_idle");
    }

    public void OnAttack(InputValue value)
    {
        Vector2 attackInput = value.Get<Vector2>();
        Debug.Log(attackInput);

        switch (attackInput)
        {
            case var v when v.Equals(Vector2.down):
                _spriteRenderer.sprite = _sprites[1];
                break;
            case var v when v.Equals(Vector2.up):
                _spriteRenderer.sprite = _sprites[2];
                break;
            case var v0 when v0.x > 0:
                _spriteRenderer.sprite = _sprites[4];
                break;
            case var v0 when v0.x < 0:
                _spriteRenderer.sprite = _sprites[3];
                break;
            default:
                _spriteRenderer.sprite = _sprites[0];
                break;

        }
    }

    public void ChangeAnimation(string newState)
    {
        if (_currentState == newState) return;

        _animator.Play(newState);
        _currentState = newState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
