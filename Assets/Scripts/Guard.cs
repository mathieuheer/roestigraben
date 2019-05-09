using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Enemy
{
    public Vector2 guardPoint;

    public override void Awake(){
        base.Awake();
        guardPoint = transform.position;
        state = State.BeingIdle;
    }

    void FixedUpdate(){
        Trigger();
        IsAlive();
    }

    public override void Approach(){
        direction = player.transform.position - transform.position;
        if((direction).magnitude <= attackRange){
            state = State.Attacking;
            return;
        }
        if((guardPoint -  (Vector2)transform.position).magnitude >= threatDistance){
            state = State.Retreating;
            return;
        }
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public override void Retreat(){
        direction = guardPoint -  (Vector2)transform.position;
        if((direction).magnitude < 0.1){
             state = State.BeingIdle;
             return;
        }
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }


}
