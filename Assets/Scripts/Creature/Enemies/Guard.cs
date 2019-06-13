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
        HandleState();
    }

    public override void Approach(){
        direction = player.transform.position - transform.position;
        if((guardPoint -  (Vector2)transform.position).magnitude >= threatDistance || player.health <= 0){
            state = State.Retreating;
            return;
        }
        Move(direction);
    }

    public override void Retreat(){
        direction = guardPoint -  (Vector2)transform.position;
        if((direction).magnitude < 0.1){
             state = State.BeingIdle;
             return;
        }
        Move(direction);
    }


}
