using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuer : MonoBehaviour
{
    
    public float speed = 0.2f;
    public Transform player;
    public int threatDistance = 5;


    void FixedUpdate(){
        
        if((player.transform.position - transform.position).magnitude < threatDistance){

            Follow();
         
        }

    }

    void Follow(){
        Vector3 direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

}
