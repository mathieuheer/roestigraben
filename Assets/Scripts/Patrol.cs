using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Enemy
{
    Vector3 guardPoint;
    public Vector3 A;
    public Vector3 B;
    bool goingToA = true;
    

    public override void Awake(){
         guardPoint = A + (B-A)/2;
    }

    void FixedUpdate(){

        Trigger();
        IsALive();
    }
       
    public override void Approach(){
        if((transform.position - player.transform.position).magnitude <= attackRange){
            state = State.Attacking;
            Attack(); 
        }
        if((guardPoint - transform.position).magnitude >= threatDistance - 0.1){
            state = State.Retreating;
            Retreat();
        }
        direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * 1.5f*speed * Time.deltaTime);
    }

    public override void Retreat(){
        if((guardPoint - transform.position).magnitude < 0.1){      
             state = State.BeingIdle;
        }
        direction = guardPoint - transform.position;
        transform.Translate(direction.normalized * 1.5f*speed * Time.deltaTime);
    }

    public override void Idle(){
        if((player.transform.position - transform.position).magnitude <= threatDistance){
            state = State.Approaching;
            Approach();
        }
        if(goingToA){
            direction = A - transform.position;
        }else{
            direction = B - transform.position;
        }
        if((A - transform.position).magnitude < 0.1){
            goingToA = false;
        }
        if((B - transform.position).magnitude < 0.1){
            goingToA = true;
        }
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

}
