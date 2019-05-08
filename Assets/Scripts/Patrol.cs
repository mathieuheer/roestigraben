using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Enemy
{
    Vector3 Waypoint;
    public Vector3 A;
    public Vector3 B;
    bool goingToA = true;
    

    public override void Awake(){
         Waypoint = A;
    }

    void FixedUpdate(){
        Trigger();
        IsAlive();
    }
       
    public override void Approach(){
        if((transform.position - player.transform.position).magnitude <= attackRange){
            state = State.Attacking;
        }
        Waypoint = A;
        if((B - transform.position).magnitude < (A - transform.position).magnitude){      
            Waypoint = B;
        }
        if((Waypoint - transform.position).magnitude >= threatDistance - 0.1){
            state = State.Retreating;
        }
        direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * 1.5f*speed * Time.deltaTime);
    }

    public override void Retreat(){
        Waypoint = A;
        if((B - transform.position).magnitude < (A - transform.position).magnitude){      
            Waypoint = B;
        }
        if((Waypoint - transform.position).magnitude < 0.1){      
            state = State.BeingIdle;
        }
        direction = Waypoint - transform.position;
        transform.Translate(direction.normalized * 1.5f*speed * Time.deltaTime);
    }

    public override void Idle(){
        if((player.transform.position - transform.position).magnitude <= threatDistance){
            state = State.Approaching;
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
