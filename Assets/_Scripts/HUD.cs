using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    ScoreManager scoreManager;

    public string mainMenuLevelName;

    [SerializeField]
    Text text;

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
        UpdateScore(scoreManager.GetTotalScore());
    }

    void OnDisable() {
        scoreManager.scoreUpdatedEvent -= UpdateScore;
    }

    void UpdateScore(int score) {
        text.text = "Score: " + score;
        if (tweener)
            tweener.Tween(text.transform);
    }
}
