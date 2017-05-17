using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class HUD : MonoBehaviour {

    ScoreManager scoreManager;

    public string mainMenuLevelName;

    [SerializeField]
    Text text;

    [SerializeField]
    Text livesText;

    [SerializeField]
    Button backButton;

    

    public AbstractTweener tweener;

    void Awake() {
        scoreManager = FindObjectOfType<ScoreManager>();
        backButton.onClick.AddListener(BackButtonHandler);
    }

    private void BackButtonHandler() {
        SceneManager.LoadScene(mainMenuLevelName);
    }

    void OnEnable() {
        scoreManager.scoreUpdatedEvent += UpdateScore;
        scoreManager.livesUpdatedEvent += UpdateLives;
        UpdateScore(scoreManager.GetTotalScore());
        UpdateLives(scoreManager.lives);
    }

    void OnDisable() {
        scoreManager.scoreUpdatedEvent -= UpdateScore;
        scoreManager.livesUpdatedEvent -= UpdateLives;
    }

    private void UpdateLives(int lives) {
        livesText.text = "Lives: " + String.Concat(Enumerable.Repeat("♥", lives).ToArray());
    }

    void UpdateScore(int score) {
        text.text = "Score: " + score;
        if (tweener)
            tweener.Tween(text.transform);
    }
}
