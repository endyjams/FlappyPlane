using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private Scoring _score;

    private GameOverUI gameOverUI;

    private void Start() 
    {
        player = GameObject.FindObjectOfType<Player>();

        _score = GameObject.FindObjectOfType<Scoring>();

        gameOverUI = GameObject.FindObjectOfType<GameOverUI>();  
    }

    public bool ClickChecker()
    {
        return (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) ? true : false;
    }
    public void gameOver()
    {
        Time.timeScale = 0;

        _score.SaveBestScore();

        gameOverUI.ShowUI();
    }

    public void RestartGame()
    {
        gameOverUI.HideUI();
        
        Time.timeScale = 1;
        
        player.Restart();

        DestroyObstacles();

        _score.Restart();
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
