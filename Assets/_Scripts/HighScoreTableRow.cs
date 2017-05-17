using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTableRow : MonoBehaviour {

    [SerializeField]
    Text nameLabel;
    [SerializeField]
    Text scoreLabel;

    public void Load(string name, int score) {
        nameLabel.text = name;
        scoreLabel.text = score.ToString();
    }
}
