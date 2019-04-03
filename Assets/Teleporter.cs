using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    
    public float speed = 0.2f;
    public Transform player;
    public int threatDistance = 10;
    public float countdown = 0.8f;


    void FixedUpdate(){
        
        if((player.transform.position - transform.position).magnitude < threatDistance){

            countdown-= Time.deltaTime;
            if (countdown <= 0){
                Teleport();
                countdown = 1;
            }
        }

    }

    void Teleport(){
        Vector3 direction = player.transform.position - transform.position;
        transform.position = player.transform.position + direction.normalized * 2;
    }


}
