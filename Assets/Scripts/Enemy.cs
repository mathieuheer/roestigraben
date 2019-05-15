using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature {
    
    // attributes
    public int damage = 10;
    public float attackRate = 0.5f;
    public float threatDistance = 5;
    public Transform player;
    public State state;

    protected Vector2 direction;

    // states
    public enum State
    {
        Approaching,
        BeingIdle,
        Retreating,
        Dying,
        Attack,
    }

    public virtual void Awake(){

        state = State.Retreating;
    }
   
    // methodes

     public virtual void HandleState(){
        switch (state){
            case State.BeingIdle: Idle();
            break;
            case State.Approaching: Approach();
            break;
            case State.Retreating: Retreat();
            break;
            case State.Attack: Attack();
            break;
        }
    }

    public virtual void Idle(){
        if((player.transform.position - transform.position).magnitude <= threatDistance){
            state = State.Approaching;
        }
    }

    public virtual void Approach(){
        if((player.transform.position - transform.position).magnitude >= threatDistance){
            state = State.Retreating;
            return;
        }
        direction = player.transform.position - transform.position;
        Move(direction);
    }

    public virtual void Retreat(){
        state = State.BeingIdle;
    }

    public virtual void Attack()
    {
        Invoke("Retreat", attackRate);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Map")
        {
            collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            collision.gameObject.SendMessage("GetKnockedBack", (Vector3)collision.contacts[0].point - transform.position, SendMessageOptions.DontRequireReceiver);
            state = State.Attack;
        }
    } 
}
