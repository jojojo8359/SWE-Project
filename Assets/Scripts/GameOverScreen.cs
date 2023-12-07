using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText, gameOverText;

    public Scoring scoringScript;

    public void Setup(bool hasWon)
    {
        gameObject.SetActive(true);

        int score = scoringScript.currentPoints;
        pointsText.text = score.ToString() + " POINTS";
        if (hasWon)
        {
            gameOverText.text = "YOU WIN";
        }
        else if (gameOverText.text != "YOU WIN")
        {
            gameOverText.text = "GAME OVER";
        }

        int saveScore = 0; 
         // Save new highscore 
        switch (scoringScript.difficulty)
        {
            case Scoring.Difficulty.Easy:
                saveScore = PlayerPrefs.GetInt("easy_highscore", 0);
                break;
            case Scoring.Difficulty.Medium:
                saveScore = PlayerPrefs.GetInt("medium_highscore", 0);
                break;
            case Scoring.Difficulty.Hard:
                saveScore = PlayerPrefs.GetInt("hard_highscore", 0);
                break;
        }
        scoringScript.addToScores(saveScore);
        
    }
}

