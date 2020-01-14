using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform container;
    private Transform template;
    //private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        container = transform.Find("Container");
        template = container.Find("HighscoreTemplate");

        template.gameObject.SetActive(false);

        /*
        highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{ score = 1234},
            new HighScoreEntry{ score = 2234},
            new HighScoreEntry{ score = 4234},
            new HighScoreEntry{ score = 3234},
        };
        */

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
         
        for(int i = 0; i < highscores.highScoreEntryList.Count;i++ )
        {
            for(int j = 1; j < highscores.highScoreEntryList.Count; j++)
            {
                if(highscores.highScoreEntryList[j].score > highscores.highScoreEntryList[i].score)
                {
                    HighScoreEntry temp = highscores.highScoreEntryList[i];
                    highscores.highScoreEntryList[i] = highscores.highScoreEntryList[j];
                    highscores.highScoreEntryList[j] = temp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();

        foreach(HighScoreEntry highScoreEntry in highscores.highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, container, highScoreEntryTransformList);
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

        transformList.Add(transform);
    }



    public static void addScore(float timeScore)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry {score = timeScore };

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

    private void AddHighScoreEntry (float time)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = time };

    }

}
