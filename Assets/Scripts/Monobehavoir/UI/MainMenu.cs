using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource ingameMusic;

    private void Start()
    {
        ingameMusic.Play();
    }
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        ingameMusic = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
