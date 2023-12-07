using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI easyText;
    public TextMeshProUGUI mediumText;
    public TextMeshProUGUI hardText;

    void Start()
    {
        DisplayHighScores();
    }

    void DisplayHighScores()
    {
        DisplayHighScoresForDifficulty(Scoring.Difficulty.Easy, easyText);
        DisplayHighScoresForDifficulty(Scoring.Difficulty.Medium, mediumText);
        DisplayHighScoresForDifficulty(Scoring.Difficulty.Hard, hardText);
    }

    void DisplayHighScoresForDifficulty(Scoring.Difficulty difficulty, TextMeshProUGUI textMeshPro)
    {
        string difficultyString = difficulty.ToString();
        List<int> scores = GetHighScores(difficulty);

        if (scores.Count == 0)
        {
            textMeshPro.text = $"{difficultyString}\n---\n---\n---\n---\n---";
        }
        else
        {
            scores.Sort((a, b) => b.CompareTo(a)); // Sort scores in descending order

            int count = Mathf.Min(scores.Count, 5);

            string scoreText = $"{difficultyString}\n";
            for (int i = 0; i < count; i++)
            {
                scoreText += $"{scores[i]}\n";
            }

            // Fill remaining slots with ---
            for (int i = count; i < 5; i++)
            {
                scoreText += "---\n";
            }

            textMeshPro.text = scoreText;
        }
    }

    List<int> GetHighScores(Scoring.Difficulty difficulty)
    {
        List<int> highScores = new List<int>();
        switch (difficulty)
        {
            case Scoring.Difficulty.Easy:
                int easyListSize = PlayerPrefs.GetInt("easy_list_size", 0);
                for (int i = 0; i < easyListSize; i++)
                {
                    int score = PlayerPrefs.GetInt("easy_list_element_" + i, 0);
                    if (score > 0)
                    {
                        highScores.Add(score);
                    }
                }
                break;
            case Scoring.Difficulty.Medium:
                int mediumListSize = PlayerPrefs.GetInt("medium_list_size", 0);
                for (int i = 0; i < mediumListSize; i++)
                {
                    int score = PlayerPrefs.GetInt("medium_list_element_" + i, 0);
                    if (score > 0)
                    {
                        highScores.Add(score);
                    }
                }
                break;
            case Scoring.Difficulty.Hard:
                int hardListSize = PlayerPrefs.GetInt("hard_list_size", 0);
                for (int i = 0; i < hardListSize; i++)
                {
                    int score = PlayerPrefs.GetInt("hard_list_element_" + i, 0);
                    if (score > 0)
                    {
                        highScores.Add(score);
                    }
                }
                break;
        }
        return highScores;
    }
}

