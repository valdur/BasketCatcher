using System.Collections.Generic;

[System.Serializable]
public class HighScoreRecord {
    public string name;
    public int score;
}

[System.Serializable]
public class HighScoreCollection {
    public List<HighScoreRecord> records;
}