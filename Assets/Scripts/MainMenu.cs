using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level Select");
        AudioManager.Instance.PlayButtonPressSound();
    }

    public void helpScreen()
    {
        SceneManager.LoadScene("Help");
        AudioManager.Instance.PlayButtonPressSound();
    }

    public void aboutScreen()
    {
        SceneManager.LoadScene("About");
        AudioManager.Instance.PlayButtonPressSound();
    }

    public void optionsScreen()
    {
        SceneManager.LoadScene("Options");
        AudioManager.Instance.PlayButtonPressSound();
    }

    public void difficultyScreen()
    {
        SceneManager.LoadScene("Difficulty");
        AudioManager.Instance.PlayButtonPressSound();
    }

    // Functions for difficulty settings 
    public void setEasy() {
        PlayerPrefs.SetFloat("maxTime", 180);
        AudioManager.Instance.PlayButtonPressSound();
    }
    public void setMedium() {
        PlayerPrefs.SetFloat("maxTime", 120);
        AudioManager.Instance.PlayButtonPressSound();
    }
    public void setHard() {
        PlayerPrefs.SetFloat("maxTime", 60);
        AudioManager.Instance.PlayButtonPressSound();
    }

    public void highscoreScreen()
    {
        SceneManager.LoadScene("Scores");
        AudioManager.Instance.PlayButtonPressSound();
    }

    public void backButton()
    {
        SceneManager.LoadScene("Main Menu");
        AudioManager.Instance.PlayBackButtonPressSound();
    }
    // This function is only here when returning from a level 
    // so the music can reset properly!
    public void levelBackButton() {
        SceneManager.LoadScene("Init");
        AudioManager.Instance.PlayBackButtonPressSound();
    }

    public void quitGame()
    {
        Application.Quit();
        AudioManager.Instance.PlayBackButtonPressSound();
    }
    public void level1()
    {
        SceneManager.LoadScene("Level1");
        AudioManager.Instance.PlayButtonPressSound();
    }
    public void level2()
    {
        SceneManager.LoadScene("Level2");
        AudioManager.Instance.PlayButtonPressSound();
    }
    public void level3()
    {
        SceneManager.LoadScene("Level3");
        AudioManager.Instance.PlayButtonPressSound();
    }
}
