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
        newGameButton.onClick.AddListener(NewGameButtonHandler);
        newGameButton.onClick.AddListener(QuitGameButtonHandler);
    }

    private void QuitGameButtonHandler() {
        Application.Quit();
    }

    private void NewGameButtonHandler() {
        SceneManager.LoadScene(gameplayLevelName);
    }
}
