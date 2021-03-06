﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int health; 
    public int numOfKeys;
    public float[] position;
    public int maxHealth;

    public PlayerData(Player player){
        health = player.health;
        numOfKeys = player.numOfKeys;
        maxHealth = player.maxHealth;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }

}
