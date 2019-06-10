using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public static PauseMenu pauseMenu;

    public void NewGame(){
        SceneManager.LoadScene("Level1");
        PauseMenu.newGame = true;
    }

    public void LoadGame(){

        SceneManager.LoadScene(1);
        PauseMenu.newGame = false;
    }

    public void Exit(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
