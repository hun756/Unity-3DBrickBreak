using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text _scoreText;
    private int _currentScore;
    private void Awake()
    {
        instance = this;
        
        // ui update operations..
        UpdateUI();
    }

    public void AddScore(int score)
    {
        _currentScore += score;
        
        // ui update operations..
        UpdateUI();
    }

    private void UpdateUI()
    {
        _scoreText.text = "Score : " + _currentScore.ToString("D");
    }
}
