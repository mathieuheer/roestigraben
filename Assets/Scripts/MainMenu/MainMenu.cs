using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : PauseMenu
{

    public void NewGame(){
        SceneManager.LoadScene("Level1");
    }

    public override void Load(){

        SceneManager.LoadScene(1);

        base.Load();
    }

    public void Exit(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
