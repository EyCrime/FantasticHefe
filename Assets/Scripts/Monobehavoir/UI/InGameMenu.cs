using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject victoryMenuUI;

    private bool gameIsActive = true;
    private bool gameIsFinished;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameIsFinished)
        {
            PauseOrResume(gameIsActive);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadVictoryMenu();
        }
    }

    public void PauseOrResume(bool gameIsActive)
    {
        pauseMenuUI.SetActive(gameIsActive);
        Time.timeScale = gameIsActive ? 0f : 1f;
        this.gameIsActive = !gameIsActive;
    }

    public void LoadMainMenu ()
    {
        this.gameIsActive = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        gameIsFinished = false;
    }

    public void LoadVictoryMenu ()
    {
        victoryMenuUI.SetActive(gameIsActive);
        Time.timeScale = gameIsActive ? 0f : 1f;
        this.gameIsActive = !gameIsActive;
        gameIsFinished = true;
    }

    public void QuitGame ()
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
}
