using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private SpriteRenderer _image;
    private GameManager gameManager;

    private void Awake() 
    {
        _image = GetComponent<SpriteRenderer>();    
    }

    private void Start() 
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();    
    }
    private void Update() 
    {
        if (gameManager.ClickChecker())
        {
            _image.enabled = false;
        }
    }
}
