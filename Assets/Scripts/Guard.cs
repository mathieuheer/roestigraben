using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Enemy
{
    public Vector3 guardPoint;

    public override void Awake(){
         guardPoint = transform.position;
         state = State.BeingIdle;
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
        Vector3 direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public override void Retreat(){
        if((guardPoint - transform.position).magnitude < 0.1){
             state = State.BeingIdle;
        }
        Vector3 direction = guardPoint - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }


}
