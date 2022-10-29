using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverImage;

    [SerializeField] private Text _bestScore;

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
        int bestScore = PlayerPrefs.GetInt("BestScore");

        _bestScore.text = bestScore.ToString();
    }
}
