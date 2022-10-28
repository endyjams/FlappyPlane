using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _speed = 0.1f;

    [SerializeField] private float _yVariation;

    private void Awake() 
    {
        transform.Translate(Vector3.up * Random.Range(-_yVariation,_yVariation));
    }

    private void Update() 
    {  
        transform.Translate(Vector3.left * _speed * Time.deltaTime);    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Clear();
    }

    public void Clear() 
    {
        GameObject.Destroy(gameObject);
    }
}
