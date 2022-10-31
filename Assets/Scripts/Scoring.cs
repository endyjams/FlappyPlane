using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    
    public int Score { get; private set; }

    private AudioSource _scoreAudio;

    private void Awake() 
    {
        _scoreAudio =  GetComponent<AudioSource>();   
    }

    private void updateText()
    {
        _scoreText.text = Score.ToString();
    }

    public void Add() 
    {
        Score++;

        updateText();

        _scoreAudio.Play();
    }

    public void Restart()
    {
        Score = 0;

        updateText();
    }

    public void SaveBestScore()
    {
        int currentBestScore = PlayerPrefs.GetInt("BestScore");

        if (Score > currentBestScore)
        {
            PlayerPrefs.SetInt("BestScore", Score);
        }
    }
}
