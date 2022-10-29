using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _score;

    private AudioSource _scoreAudio;

    private void Awake() 
    {
        _scoreAudio =  GetComponent<AudioSource>();   
    }

    private void updateText()
    {
        _scoreText.text = _score.ToString();
    }

    public void Add() 
    {
        _score++;

        updateText();

        _scoreAudio.Play();
    }

    public void Restart()
    {
        _score = 0;

        updateText();
    }

    public void SaveBestScore()
    {
        int currentBestScore = PlayerPrefs.GetInt("BestScore");

        if (_score > currentBestScore)
        {
            PlayerPrefs.SetInt("BestScore", _score);
        }
    }
}
