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
    [SerializeField] private SignalObject playerHealthSignal;
    [SerializeField] private SignalObject scoreSignal;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI gameOverReason;
    [SerializeField] private Timer timer;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource victorySound;


    private bool gameIsActive = true;
    private bool gameIsFinished;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameIsFinished)
        {
            PauseOrResume();
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
        if(isVictory) 
        {
            playerInventory.score += (int)(timer.currentTime) * 10;
        
            scoreSignal.Raise(); 
            scoreUI.text = playerInventory.score.ToString();

            victorySound.Play();
            victoryMenuUI.SetActive(true);
        }
        else 
        {
            gameOverReason.text = playerInventory.gameOverReason;

            playerInventory.currentHealth = 0;
            playerHealthSignal.Raise();
            
            gameOverSound.Play();
            gameOverMenuUI.SetActive(true);
        }

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
}
