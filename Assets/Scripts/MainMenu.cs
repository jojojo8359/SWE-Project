using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void helpScreen()
    {
        SceneManager.LoadScene("Help");
    }

    public void aboutScreen()
    {
        SceneManager.LoadScene("About");
    }

    public void optionsScreen()
    {
        SceneManager.LoadScene("Options");
    }

    public void difficultyScreen()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void highscoreScreen()
    {
        SceneManager.LoadScene("Scores");
    }

    public void backButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
    // This function is only here when returning from a level 
    // so the music can reset properly!
    public void levelBackButton() {
        SceneManager.LoadScene("Init");
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void level2()
    {
        SceneManager.LoadScene("Level2");
    }
}
