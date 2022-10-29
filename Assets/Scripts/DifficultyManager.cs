using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private float _maxDifficultyTime;  
    
    private float _currentTime;
    
    public float Difficulty { get; private set; }
    
    private void Update() 
    {
        _currentTime += Time.deltaTime;

        Difficulty = _currentTime / _maxDifficultyTime;

        Difficulty = Mathf.Min(Difficulty, 1);
    }
}
