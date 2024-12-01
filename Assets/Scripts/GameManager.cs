using TMPro;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int bestScore1; // new variable declared
    public int bestScore2; // new variable declared
    public int bestScore3; // new variable declared

    public string playerName; // new variable declared
    public TMP_InputField playerNameInput;


    public string name1; // new variable declared
    public string name2; // new variable declared
    public string name3; // new variable declared

    public TextMeshProUGUI bestScore1Text;
    public TextMeshProUGUI bestScore2Text;
    public TextMeshProUGUI bestScore3Text;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        bestScore1Text.text = $"Best Score : {bestScore1}" + $" Name : {name1}";
        bestScore2Text.text = $"Best Score : {bestScore2}" + $" Name : {name2}";
        bestScore3Text.text = $"Best Score : {bestScore3}" + $" Name : {name3}";

        LoadData();
    }

    public void SetBestScore(int newScore)
    {
        if(newScore > bestScore1)
        {
            bestScore3 = bestScore2;
            bestScore2 = bestScore1;
            bestScore1 = newScore;

            name3 = name2;
            name2 = name1;
            name1 = playerName;
        }
        else if (newScore > bestScore2)
        {
            bestScore3 = bestScore2;
            bestScore2 = newScore;

            name3 = name2;
            name2 = playerName;
        }
        else if (newScore > bestScore3)
        {
            bestScore3 = newScore;

            name3 = playerName;
        }
    }

    public void UpdateBestScorTable()
    {
        bestScore1Text.text = $"Best Score : {bestScore1}" + $" Name : {name1}";
        bestScore2Text.text = $"Best Score : {bestScore2}" + $" Name : {name2}";
        bestScore3Text.text = $"Best Score : {bestScore3}" + $" Name : {name3}";
    }
    public void UpdatePlayerName()
    {
        if (playerNameInput.text.Length == 0)
        {
            playerName = "Anonymous";
        }
        else
        {
            playerName = playerNameInput.text;
        }
    }

    [System.Serializable]
    class SaveDataValues
    {
        public int bestScore1;
        public int bestScore2;
        public int bestScore3;
        public string name1;
        public string name2;
        public string name3;
    }

    public void SaveData()
    {
        SaveDataValues data = new SaveDataValues();
        data.bestScore1 = bestScore1;
        data.bestScore2 = bestScore2;
        data.bestScore3 = bestScore3;
        data.name1 = name1;
        data.name2 = name2;
        data.name3 = name3;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataValues data = JsonUtility.FromJson<SaveDataValues>(json);

            bestScore1 = data.bestScore1;
            bestScore2 = data.bestScore2;
            bestScore3 = data.bestScore3;
            name1 = data.name1;
            name2 = data.name2;
            name3 = data.name3;
        }
    }
}
