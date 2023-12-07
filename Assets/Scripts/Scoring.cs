using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Scoring : MonoBehaviour
{
    // Define difficulty levels
    public enum Difficulty { Easy, Medium, Hard }

    // Store the current difficulty level
    public Difficulty difficulty;

    public int currentPoints = 0;
    private int currentHighscore = 0;
    List<int> easyList = new List<int>();
    List<int> mediumList = new List<int>();
    List<int> hardList = new List<int>();

    public TextMeshProUGUI curPointText;

    private void Awake() {
        // Set difficulty based on maxTime
        float maxTime = PlayerPrefs.GetFloat("maxTime", 120f); // Default to medium
        difficulty = GetDifficultyFromMaxTime(maxTime);
    }

    private void Start()
    {
        // Clear the lists before populating it to avoid duplicate zeros
        easyList.Clear();
        mediumList.Clear();
        hardList.Clear();

        // Get correct highsore list 
        switch(difficulty) {
            case Difficulty.Easy:
                // Get the list of previous highscores for easy 
                int easyListSize = PlayerPrefs.GetInt("easy_list_size", 0);
                for (int i = 0; i < easyListSize; i++)
                {
                    int score = PlayerPrefs.GetInt("easy_list_element_" + i, 0);
                    if (score > 0)
                    {
                        easyList.Add(score);
                    }
                }
                currentHighscore = PlayerPrefs.GetInt("easy_highscore", 0);
                break;
            case Difficulty.Medium:
                // Get the list of previous highscores for medium 
                int mediumListSize = PlayerPrefs.GetInt("medium_list_size", 0);
                for (int i = 0; i < mediumListSize; i++)
                {
                    int score = PlayerPrefs.GetInt("medium_list_element_" + i, 0);
                    if (score > 0)
                    {
                        mediumList.Add(score);
                    }
                }
                currentHighscore = PlayerPrefs.GetInt("medium_highscore", 0);
                break;
            case Difficulty.Hard:
                // Get the list of previous highscores for hard 
                int hardListSize = PlayerPrefs.GetInt("hard_list_size", 0);
                for (int i = 0; i < hardListSize; i++)
                {
                    int score = PlayerPrefs.GetInt("hard_list_element_" + i, 0);
                    if (score > 0)
                    {
                        hardList.Add(score);
                    }
                }
                currentHighscore = PlayerPrefs.GetInt("hard_highscore", 0);
                break;
        }
    }

    private Difficulty GetDifficultyFromMaxTime(float maxTime)
    {
        if (maxTime == 180f)
            return Difficulty.Easy;
        else if (maxTime == 120f)
            return Difficulty.Medium;
        else if (maxTime == 60f)
            return Difficulty.Hard;
        else
            return Difficulty.Medium; // Default to medium if maxTime is not recognized
    }

    public void AddPoint(int points) {
        // Add 100 points to current score
        currentPoints += points;

        // Debug log to check the current score
        Debug.Log($"Current Score: {currentPoints}");
        curPointText.text = "Points: " + currentPoints;

        // If current points exeeds the previous highscore, set it as new highscore
        if(currentHighscore < currentPoints) {
            switch (difficulty) {
                case Difficulty.Easy:
                    PlayerPrefs.SetInt("easy_highscore", currentPoints);
                    break;
                case Difficulty.Medium:
                    PlayerPrefs.SetInt("medium_highscore", currentPoints);
                    break;
                case Difficulty.Hard:
                    PlayerPrefs.SetInt("hard_highscore", currentPoints);
                    break;
            }
        }
    }

    public void addToScores(int highScore) {
        switch(difficulty) {
            case Difficulty.Easy:
                // Easy 
                if(highScore != 0 && !easyList.Contains(highScore)) {
                    easyList.Add(highScore);
                } 
                PlayerPrefs.SetInt("easy_list_size", easyList.Count);
                for(int i = 0; i < easyList.Count; i++) {
                    PlayerPrefs.SetInt("easy_list_element_" + i, easyList[i]);
                }
                break;
            case Difficulty.Medium:
                // Medium 
                if(highScore != 0 && !mediumList.Contains(highScore)) {
                    mediumList.Add(highScore);
                } 
                PlayerPrefs.SetInt("medium_list_size", mediumList.Count);
                for(int i = 0; i < mediumList.Count; i++) {
                    PlayerPrefs.SetInt("medium_list_element_" + i, mediumList[i]);
                }
                break;
            case Difficulty.Hard:
                // Hard
                if(highScore != 0 && !hardList.Contains(highScore)) {
                    hardList.Add(highScore);
                } 
                PlayerPrefs.SetInt("hard_list_size", hardList.Count);
                for(int i = 0; i < hardList.Count; i++) {
                    PlayerPrefs.SetInt("hard_list_element_" + i, hardList[i]);
                }
                break;
        }
    }
}
