using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    
    public float speed = 0.2f;
    public Transform player;
    public int threatDistance = 5;
    public int space = 6;
    public Vector3 A;
    public Vector3 B;
    public Vector3 guardPoint;
    public Vector3 path = new Vector3(0, 2, 0);
    public Vector3 direction;
    public bool isFollowing = false;
    public bool goBack = false;
    bool beginPatrol = true;

    void Awake(){
         guardPoint = transform.position;
         A = guardPoint + path;
         B = guardPoint - path;
    }

    void FixedUpdate(){

        if((player.transform.position - transform.position).magnitude < threatDistance &&
            (transform.position - guardPoint).magnitude < space && !goBack){

            isFollowing = true;
            beginPatrol = false;
            speed = 5f;
            follow();
         
        }else if((guardPoint - transform.position).magnitude > 0.1 && isFollowing ){
            backToGuardPoint();
        }else{
            patrol();
        }


    }

    void follow(){
        if((transform.position - guardPoint).magnitude >= space -0.1){
            goBack = true;
        }
        direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    void backToGuardPoint(){
        direction = guardPoint - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        if((guardPoint - transform.position).magnitude < 0.1){
            beginPatrol = true;
            isFollowing = false;
            goBack = false;
        }
    }

    void patrol(){
        speed = 2f;
        if(beginPatrol){
            direction = A - transform.position;
        }
        if((A - transform.position).magnitude < 0.1){
            direction = B - transform.position;
            beginPatrol = false;
        }
        if((B - transform.position).magnitude < 0.1){
            direction = A - transform.position;
            beginPatrol = false;
        }
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

}
