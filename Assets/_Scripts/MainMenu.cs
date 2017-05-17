using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string gameplayLevelName;

    public Button newGameButton;
    public Button quitGameButton;

    void Awake() {
        newGameButton.onClick.AddListener(SceneSwitcher.LoadGameplay);
        quitGameButton.onClick.AddListener(Application.Quit);
    }
}
