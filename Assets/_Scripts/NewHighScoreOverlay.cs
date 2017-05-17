using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewHighScoreOverlay : MonoBehaviour {

    public InputField input;
    public Text scoreLabel;

    public Button okButton;

    System.Action<string> callback;

    public void Show(int score, System.Action<string> callback) {
        gameObject.SetActive(true);
        scoreLabel.text = score.ToString();
        this.callback = callback;
        okButton.onClick.AddListener(Submit);
    }

    public void Submit() {
        callback(input.text);
        gameObject.SetActive(false);
    }

}
