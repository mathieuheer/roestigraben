using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Enemy
{
    
    public float countdown = 2f;
    float timer;
    public float jumpAhead = 2f;

    public override void Awake(){
        base.Awake();
        timer = countdown;
    }

    void FixedUpdate(){
        Trigger();
        IsAlive();
    }

    public override void Approach(){
        if((player.transform.position - transform.position).magnitude <= attackRange){
            state = State.Attacking;
            return;
        }
        if((player.transform.position - transform.position).magnitude >= threatDistance){
            state = State.Retreating;
            return;
        }
        timer-= Time.deltaTime;
        if (timer <= 0){
            direction = player.transform.position - transform.position;
            transform.position = (Vector2)player.transform.position + direction.normalized * jumpAhead;
            timer = countdown;
        }
    }


}
