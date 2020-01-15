using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Transform container;
    private Transform template;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private void Start()
    {
        highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{ score = 9999},
            new HighScoreEntry{ score = 9999},
            new HighScoreEntry{ score = 9999},
            new HighScoreEntry{ score = 9999},
            new HighScoreEntry{ score = 9999},
            new HighScoreEntry{ score = 9999},
            new HighScoreEntry{ score = 9999},
            new HighScoreEntry{ score = 9999},
            new HighScoreEntry{ score = 9999},
        };

        Highscores highscoresDemo = new Highscores { highScoreEntryList = highScoreEntryList };

        string json = JsonUtility.ToJson(highscoresDemo);

        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
    }
    private void Awake()
    {
        Debug.Log("Log");
        container = transform.Find("Container");
        template = container.Find("HighscoreTemplate");

        template.gameObject.SetActive(false);

       


        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);



        for (int i = 0; i < highscores.highScoreEntryList.Count - 1; i++)
        {   
            for (int j = 0; j < highscores.highScoreEntryList.Count - 1; j++)
            {
                if (highscores.highScoreEntryList[j].score > highscores.highScoreEntryList[j + 1].score)
                {
                    HighScoreEntry temp = highscores.highScoreEntryList[j];
                    highscores.highScoreEntryList[j] = highscores.highScoreEntryList[j + 1];
                    highscores.highScoreEntryList[j + 1] = temp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();


        //foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
        //{
        //    CreateHighScoreEntryTransform(highScoreEntry, container, highScoreEntryTransformList);
        //}


        for (int i = 0; i <highscores.highScoreEntryList.Count && i < 10; i++)
        {
            CreateHighScoreEntryTransform(highscores.highScoreEntryList[i], container, highScoreEntryTransformList);
        }

    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform constainer, List<Transform> transformList)
    {
        float templateHight = 20.0f;

        Transform transform = Instantiate(template, container);
        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, -templateHight * transformList.Count);
        transform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default: rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        transform.Find("PosText").GetComponent<Text>().text = rankString;

        float score = highScoreEntry.score;

        transform.Find("ScoreText").GetComponent<Text>().text = score.ToString();


        transform.Find("background").gameObject.SetActive(rank % 2 == 1) ;

        if (rank == 1)
        {
            transform.Find("ScoreText").GetComponent<Text>().color = Color.yellow;
            transform.Find("PosText").GetComponent<Text>().color = Color.yellow;
        }
        transformList.Add(transform);
    }



    public static void addScore(float timeScore)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = timeScore };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highScoreEntryList.Add(highScoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }

    public class Highscores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    public class HighScoreEntry
    {
        public float score;
    }

    private void AddHighScoreEntry(float time)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = time };

    }

}