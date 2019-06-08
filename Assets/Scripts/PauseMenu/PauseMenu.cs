﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public Player player;

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

    public void Resume(){
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause(){
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Save(){
         SaveSystem.SavePlayer(player);
    }

    public virtual void Load(){

        PlayerData data = SaveSystem.LoadPlayer();

        player.health = data.health;
        player.numOfKeys = data.numOfKeys;

        Vector3 position;
        position.x = data.position[0];
        position.y= data.position[1];
        position.z = data.position[2];
        player.transform.position = position;

        player.UpdateHearts();

        player.GetComponent<Renderer>().enabled = true;
        player.gameObject.SetActive(true);

        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }
}
