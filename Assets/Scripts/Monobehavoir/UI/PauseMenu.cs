using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;

    private bool gameIsActive = true;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrResume(gameIsActive);
        }
    }

    public void PauseOrResume(bool gameIsActive)
    {
        pauseMenuUI.SetActive(gameIsActive);
        Time.timeScale = gameIsActive ? 0f : 1f;
        this.gameIsActive = !gameIsActive;
    }

    public void LoadMenu ()
    {
        this.gameIsActive = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
