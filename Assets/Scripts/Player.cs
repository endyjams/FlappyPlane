using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _strength;

    [SerializeField] private Sprite[] _sprites;

    private SpriteRenderer spriteRenderer;

    private int _spriteIndex;

    private Vector3 _initialPosition;

    private GameManager gameManager;

    private void Awake() 
    {
        _initialPosition = transform.position;

        _rb = GetComponent<Rigidbody2D>();   

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);

        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void AnimateSprite()
    {
        _spriteIndex++;

        if (_spriteIndex >= _sprites.Length)
        {
            _spriteIndex = 0;
        }

        spriteRenderer.sprite = _sprites[_spriteIndex];
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
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        _rb.simulated = false;

        gameManager.gameOver();
    }
}
