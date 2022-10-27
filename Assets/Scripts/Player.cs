using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _strength = 5f;

    private void Awake() 
    {
        _rb = this.GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * _strength, ForceMode2D.Impulse);
    }
}
