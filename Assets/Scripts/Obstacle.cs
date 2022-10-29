using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private SharedVariableFloat _speed;

    [SerializeField] private float _yVariation;

    private Scoring _score;

    private bool _didScore;

    private Vector3 _playerPosition;

    private void Awake() 
    {
        transform.Translate(Vector3.up * Random.Range(-_yVariation,_yVariation));
    }

    private void Start() 
    {
        _playerPosition = GameObject.FindObjectOfType<Player>().transform.position;

        _score = GameObject.FindObjectOfType<Scoring>();    
    }

    private void Update() 
    {  
        transform.Translate(Vector3.left * _speed.value * Time.deltaTime);

        if (!_didScore && transform.position.x < _playerPosition.x)
        {
            _didScore = true;

            _score.Add();
        }
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
