using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonHandling : MonoBehaviour
{

    public void Continue(){
        SceneManager.LoadScene(1);
    }

    public void NewGame(){
        SceneManager.LoadScene(1);
    }

    public void Save(){
    }

    public void Load(){
    }

    public void Exit(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
