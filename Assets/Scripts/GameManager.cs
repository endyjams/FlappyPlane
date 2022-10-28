using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverImage;

    [SerializeField] private Player player;

    private void Start() 
    {
        player = GameObject.FindObjectOfType<Player>();    
    }
    public void gameOver()
    {
        Time.timeScale = 0;

        _gameOverImage.SetActive(true);
    }

    public void RestartGame()
    {
        _gameOverImage.SetActive(false);
        
        Time.timeScale = 1;
        
        player.Restart();

        DestroyObstacles();
    }

    private void DestroyObstacles()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();

        foreach(Obstacle obstacle in obstacles)
        {
            obstacle.Clear();
        }
    }
}
