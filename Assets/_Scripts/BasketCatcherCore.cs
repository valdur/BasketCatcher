using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCatcherCore : MonoBehaviour {

    public static BasketCatcherCore instance { get; private set; }
    public bool justLost { get; private set; }
    public int lastScore { get; private set; }

    // Use this for initialization
    void Awake() {
        if (instance != null)
            DestroyImmediate(gameObject);
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public enum GameState { Normal, JustLost }

    public void SubmitScore(int score) {
        justLost = true;
        lastScore = score;
    }

    public void ConsumeScore() {
        justLost = false;
    }

}
