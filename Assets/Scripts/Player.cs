using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _strength;

    private Vector3 _initialPosition;

    private GameManager gameManager;

    private void Awake() 
    {
        _initialPosition = transform.position;

        _rb = this.GetComponent<Rigidbody2D>();   
    }

    private void Start() 
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
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
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        _rb.simulated = false;

        gameManager.gameOver();
    }
}
