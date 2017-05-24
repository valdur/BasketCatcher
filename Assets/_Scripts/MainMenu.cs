using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MainMenu : MonoBehaviour {

    public string gameplayLevelName;

    public Button newGameButton;
    public Button quitGameButton;
    public Button startServerButton;
    public Button startClientButton;
    public InputField addressField;

    void Awake() {
        newGameButton.onClick.AddListener(NewGame);
        quitGameButton.onClick.AddListener(Application.Quit);
        startServerButton.onClick.AddListener(StartServer);
        startClientButton.onClick.AddListener(StartClient);
    }

    private void NewGame() {
        SceneSwitcher.LoadGameplay();
    }

    private void StartServer() {
        SceneSwitcher.LoadGameplay();
    }

    private void StartClient() {
        SceneSwitcher.LoadGameplay();
    }
}
