using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;

    private void Update() 
    {  
        transform.Translate(Vector3.left * _speed);    
    }
}
