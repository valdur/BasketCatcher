using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private int totalScore;

    public event System.Action<int> scoreUpdatedEvent;

    public void AddPoints(int points) {
        totalScore += points;
        if (scoreUpdatedEvent != null)
            scoreUpdatedEvent(totalScore);
    }

    public int GetTotalScore() {
        return totalScore;
    }
}
