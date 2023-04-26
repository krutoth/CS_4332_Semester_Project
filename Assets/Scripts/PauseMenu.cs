using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                
                Resume();
            }
            else
            {
                Cursor.visible = true;
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!gameIsPaused)
            {
                LoadMenu();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Pressed Resume");
        Cursor.visible = false;
        player.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause() 
    {
        //player.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // launches start menu
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
