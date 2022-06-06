using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;


    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false); //Když je PauseMenu neaktivní
        Time.timeScale = 1f; //obnoví èas
        GamePaused = false;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true); //když je PauseMenu aktivní
        Time.timeScale = 0f; //zastaví èas
        GamePaused = true; 
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameMenu");
        //SceneManager.LoadScene(sceneID);

    }
    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }
}
