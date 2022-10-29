using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _strength;

    private SpriteRenderer spriteRenderer;

    private int _spriteIndex;

    private Vector3 _initialPosition;

    private GameManager gameManager;

    private bool _shouldJump;

    private Animator playerAnimation;

    private void Awake() 
    {
        _initialPosition = transform.position;

        _rb = GetComponent<Rigidbody2D>();

        playerAnimation = GetComponent<Animator>();
    }

    private void Start() 
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager.ClickChecker())
        {
            _shouldJump = true;
        }

        playerAnimation.SetFloat("ySpeed", _rb.velocity.y);
    }

    private void FixedUpdate() 
    {
        if (_shouldJump)
        {
            Jump();
        }    
    }

    public void Restart()
    {
        transform.position = _initialPosition;

        _rb.simulated = true;
    }

    private void Jump()
    {
        _rb.velocity = Vector2.zero;

        _rb.AddForce(Vector2.up * _strength, ForceMode2D.Impulse);

        _shouldJump = false;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        _rb.simulated = false;

        gameManager.gameOver();
    }
}
