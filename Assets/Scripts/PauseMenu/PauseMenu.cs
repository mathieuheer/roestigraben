using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Awake(){
        Resume();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    void Resume(){
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause(){
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }

}
