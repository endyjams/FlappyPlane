using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _initialPosition;

    private float _actualImageSize;

    private void Awake() 
    {
        _initialPosition = transform.position;

        float _imageSize = GetComponent<SpriteRenderer>().size.x;

        float _scale = transform.localScale.x;

        _actualImageSize = _imageSize * _scale;
    }

    private void Update() 
    {
        float _displacement = Mathf.Repeat(_speed * Time.time, _actualImageSize);

        transform.position = _initialPosition + Vector3.left * _displacement;
    }
}
