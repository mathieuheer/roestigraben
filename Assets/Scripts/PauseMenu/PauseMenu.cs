using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool newGame = true;

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

    public void Load(){

        PlayerData data = SaveSystem.LoadPlayer();

        Player.health = data.health;
        Player.numOfKeys = data.numOfKeys;
        player.maxHealth = data.maxHealth;
        player.level = data.level;
        
        Vector3 position;
        position.x = data.position[0];
        position.y= data.position[1];
        position.z = data.position[2];
        player.transform.position = position;

        player.UpdateHearts();

        player.GetComponent<Renderer>().enabled = true;
        player.gameObject.SetActive(true);

        // SceneManager.LoadScene(player.level);
        SceneManager.LoadScene(2);

        Resume();

    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }

    // void OnEnable()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }

    // void OnDisable()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode){
    //     if(!newGame){
    //         Load();
    //     }else{
    //         Save();
    //     }
    // }

}
