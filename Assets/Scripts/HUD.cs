using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    ScoreManager scoreManager;

    [SerializeField]
    Text text;

    void Awake() {
        scoreManager = FindObjectOfType<ScoreManager>();
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
    }
}
