using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _easySpawnTime;

    [SerializeField] private float _hardSpawnTime;

    [SerializeField] private GameObject _Instructions;

    private float _shouldSpawn;

    private DifficultyManager difficultyManager; 

    private void Awake() 
    {
        _shouldSpawn = _easySpawnTime;
    }

    private void Start() 
    {
        difficultyManager = GameObject.FindObjectOfType<DifficultyManager>();
    }

    private void Update()
    {
        _shouldSpawn -= Time.deltaTime;

        if (_shouldSpawn < 0)
        {
            GameObject.Instantiate(_Instructions, transform.position, Quaternion.identity);
            
            _shouldSpawn = Mathf.Lerp(_easySpawnTime, _hardSpawnTime, difficultyManager.Difficulty);
        }
    }
}
