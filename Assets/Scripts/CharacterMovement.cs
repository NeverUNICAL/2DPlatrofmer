using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterMovement : MonoBehaviour
{
   
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _movementSpeed;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool _isGrounded;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            Run();
        
        else if(_animator.GetBool("isRun"))
            _animator.SetBool("isRun",false);
        
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.SetBool("isJump",false);
        
        if (collision.gameObject.GetComponent<Ground>())
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _animator.SetBool("isJump",true);
        
        if (collision.gameObject.GetComponent<Ground>())
            _isGrounded = false;
    }

    private void Run()
    {
        _animator.SetBool("isRun",true);
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_movementSpeed*Time.deltaTime,0,0);
            _spriteRenderer.flipX = false;
        }
        else
        {
            transform.Translate(_movementSpeed*Time.deltaTime * -1,0,0);
            _spriteRenderer.flipX = true;
        }
    }
}