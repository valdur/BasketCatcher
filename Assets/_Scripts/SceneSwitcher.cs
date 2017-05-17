using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSwitcher {

    public const string SCN_MAIN_MENU = "MainMenu";
    public const string SCN_GAMEPLAY = "Gameplay";
    public const string SCN_HIGHSCORES = "HighScores";

    public static void LoadMainMenu() {
        SceneManager.LoadScene(SCN_MAIN_MENU);
    }

    public static void LoadGameplay() {
        SceneManager.LoadScene(SCN_GAMEPLAY);
    }

    public static void LoadHighScores() {
        SceneManager.LoadScene(SCN_HIGHSCORES);
    }
}
