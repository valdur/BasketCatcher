using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class HighScores : MonoBehaviour {

    [Header("Prefabs")]
    public HighScoreTableRow tableRowPrefab;

    [Header("Internal Refs")]
    public Button newGameButton;
    public Button menuButton;

    public NewHighScoreOverlay newHighScoreOverlay;

    public Transform table;

    BasketCatcherCore core;
    const string filename = "highscores.json";
    HighScoreCollection highScoreCollection;
    int newHighScore;

    string MakePath() {
        return Application.persistentDataPath + "/" + filename;
        // return Path.Combine(Application.persistentDataPath, filename);
    }

    void Start() {
        newHighScoreOverlay.gameObject.SetActive(false);
        newGameButton.onClick.AddListener(SceneSwitcher.LoadGameplay);
        menuButton.onClick.AddListener(SceneSwitcher.LoadMainMenu);
        table.gameObject.SetActive(false);

        core = BasketCatcherCore.instance;
        newGameButton.gameObject.SetActive(core.justLost);

        LoadHighScores();

        if (core.justLost) {
            newHighScore = BasketCatcherCore.instance.lastScore;

            var minRecordScore = 0;
            if (highScoreCollection.records.Count >= 10) {
                minRecordScore = highScoreCollection.records.Select(x => x.score).Min();
            }

            if (newHighScore > minRecordScore) {
                newHighScoreOverlay.Show(newHighScore, NameSubmitted);
            } else {
                LoadTable();
            }
            core.ConsumeScore();
        } else {
            LoadTable();
        }
    }

    public void LoadHighScores() {
        var p = MakePath();
        if (File.Exists(p)) {
            highScoreCollection = JsonUtility.FromJson<HighScoreCollection>(File.ReadAllText(p));
        } else {
            highScoreCollection = new HighScoreCollection();
            highScoreCollection.records = new List<HighScoreRecord>();
        }
    }

    public void NameSubmitted(string name) {
        highScoreCollection.records.Add(new HighScoreRecord() { name = name, score = newHighScore });
        highScoreCollection.records = highScoreCollection.records.OrderByDescending(x => x.score).Take(10).ToList();
        SaveHighScores();
        LoadTable();
    }

    public void SaveHighScores() {
        File.WriteAllText(MakePath(), JsonUtility.ToJson(highScoreCollection, true));
        Debug.Log(MakePath());
    }

    public void LoadTable() {
        if (highScoreCollection.records.Count > 0)
            table.gameObject.SetActive(true);
        foreach (var hsr in highScoreCollection.records) {
            var ins = Instantiate(tableRowPrefab, table) as HighScoreTableRow;
            ins.Load(hsr.name, hsr.score);
        }
    }

}
