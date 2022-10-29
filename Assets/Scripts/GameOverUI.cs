using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverImage;

    [SerializeField] private Text _bestScoreText;

    [SerializeField] private Image _medalPosition;

    [SerializeField] private Sprite _goldMedal;

    [SerializeField] private Sprite _silverMedal;

    [SerializeField] private Sprite _bronzeMedal;

    private Scoring score;

    private int _bestScore;

    private void Start() 
    {
        score = GameObject.FindObjectOfType<Scoring>();  
    }

    public void ShowUI()
    {
        _gameOverImage.SetActive(true);

        UpdateUI();
    }

    public void HideUI()
    {
        _gameOverImage.SetActive(false);
    }

    private void UpdateUI()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore");

        _bestScoreText.text = _bestScore.ToString();

        CheckMedal();
    }

    private void CheckMedal()
    {
        if (score.Score > _bestScore)
        {
            _medalPosition.sprite = _goldMedal;
        }
        else if (score.Score > _bestScore/2)
        {
            _medalPosition.sprite = _silverMedal;
        } 
        else 
        {
            _medalPosition.sprite = _bronzeMedal;
        }
    }
}
