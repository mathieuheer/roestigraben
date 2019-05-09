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
        HandleState();
    }

    public override void Approach(){
        direction = player.transform.position - transform.position;
        if((direction).magnitude >= threatDistance){
            state = State.Retreating;
            return;
        }
            timer-= Time.deltaTime;
        if((direction).magnitude <= jumpAhead){
            SetDirection(direction);
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }else{
            if (timer <= 0){
                transform.position = (Vector2)player.transform.position + direction.normalized * jumpAhead;
                timer = countdown;
            }
        }
    }


}
