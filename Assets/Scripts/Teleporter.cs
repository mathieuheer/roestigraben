using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Enemy
{
    
    public float countdown = 2f;
    float timer;
    public float jumpAhead = 3f;

    public override void Awake(){
         timer = countdown;
    }

    void FixedUpdate(){
        Trigger();
        IsAlive();
    }

    public override void Approach(){
        if((transform.position - player.transform.position).magnitude <= attackRange){
            state = State.Attacking;
        }
        if((player.transform.position - transform.position).magnitude >= threatDistance - 0.1){
            state = State.Retreating;
        }
        timer-= Time.deltaTime;
        if (timer <= 0){
            direction = player.transform.position - transform.position;
            transform.position = player.transform.position + direction.normalized * jumpAhead;
            timer = countdown;
        }
    }


}
