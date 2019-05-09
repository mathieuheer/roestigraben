using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    
    // attributes
    public int health = 100;
    public int damage = 10;
    public float speed = 5f;
    public float attackRange = 2;
    public float threatDistance = 5;
    public Transform player;
    public State state;
    protected Vector2 direction;

    // states
    public enum State
    {
        Approaching,
        Attacking, 
        BeingIdle,
        Retreating,
        Dying,
    }

    public virtual void Awake(){
        state = State.Retreating;
    }
   
    // methodes

     public virtual void Trigger(){
        switch (state){
            case State.BeingIdle: Idle();
            break;
            case State.Approaching: Approach();
            break;
            case State.Attacking: Attack();
            break;
            case State.Retreating: Retreat();
            break;
            case State.Dying: Die();
            break;
        }
    }

    public virtual void Idle(){
        if((player.transform.position - transform.position).magnitude <= threatDistance){
            state = State.Approaching;
        }
    }

    public virtual void Approach(){
        if((player.transform.position - transform.position).magnitude <= attackRange){
            state = State.Attacking;
            return;
        }
        if((player.transform.position - transform.position).magnitude >= threatDistance){
            state = State.Retreating;
            return;
        }
        direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public virtual void Attack(){
        if((player.transform.position - transform.position).magnitude >= attackRange){
            state = State.Approaching;
            return;
        }
        if((player.transform.position - transform.position).magnitude >= threatDistance - 0.1){
            state = State.Retreating;
        }
    }
    public virtual void Retreat(){
        state = State.BeingIdle;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("DAMAGE");
    }

    public virtual void DoDamage(int damage)
    {
        health -= damage;
        Debug.Log("DAMAGE");
    }
    public virtual void IsAlive(){
        if(health <= 0){
            state = State.Dying;
        }
    }

    public virtual void Die(){
        
    }

}
