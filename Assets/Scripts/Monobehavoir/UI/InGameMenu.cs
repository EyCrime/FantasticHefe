using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject victoryMenuUI;
    [SerializeField] private GameObject gameOverMenuUI;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private Timer timer;

    private bool gameIsActive = true;
    private bool gameIsFinished;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameIsFinished)
        {
            PauseOrResume();
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            LoadScreen(true);
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            LoadScreen(false);
        }
    }

    public void PauseOrResume()
    {
        pauseMenuUI.SetActive(gameIsActive);
        Time.timeScale = gameIsActive ? 0f : 1f;
        gameIsActive = !gameIsActive;
    }

    public void LoadMainMenu()
    {
        gameIsActive = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        gameIsFinished = false;
    }

    public void LoadScreen(bool isVictory)
    {
        scoreUI.text = "" + calcFinalScore();
        
        if(isVictory)
            victoryMenuUI.SetActive(true);
        else
            gameOverMenuUI.SetActive(true);

        Time.timeScale = 0f;
        gameIsActive = false;
        gameIsFinished = true;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void RestartGame()
    {
        this.gameIsActive = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameIsFinished = false;
    }

    private int calcFinalScore()
    {
        return playerInventory.score + (int)(timer.currentTime) * 10;
    } 
}
