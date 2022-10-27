using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime;

    [SerializeField] private GameObject _Instructions;

    private float _shouldSpawn; 

    private void Awake() 
    {
        _shouldSpawn = _spawnTime;
    }

    private void Update()
    {
        DecreaseTime();

        if (_shouldSpawn < 0)
        {
            GameObject.Instantiate(_Instructions, transform.position, Quaternion.identity);
            
            Awake();
        }
    }

    private void DecreaseTime()
    {
        _shouldSpawn -= Time.deltaTime;
    }
}
