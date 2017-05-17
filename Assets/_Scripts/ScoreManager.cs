using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private int totalScore;

    public int lives = 10;

    public event System.Action<int> scoreUpdatedEvent;
    public event System.Action<int> livesUpdatedEvent;

    public void AddPoints(int points) {
        totalScore += points;
        if (scoreUpdatedEvent != null)
            scoreUpdatedEvent(totalScore);
    }

    public int GetTotalScore() {
        return totalScore;
    }

    public void LoseLife() {
        lives--;
        if (livesUpdatedEvent != null)
            livesUpdatedEvent(lives);

        if (lives <= 0) {
            BasketCatcherCore.instance.SubmitScore(totalScore);
            SceneSwitcher.LoadHighScores();
        }
    }
}
