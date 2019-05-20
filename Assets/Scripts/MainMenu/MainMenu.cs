using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{

    public Player player;

    public void NewGame(){
        SceneManager.LoadScene(1);
    }

    public void Load(){

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

    }

    public void Exit(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
