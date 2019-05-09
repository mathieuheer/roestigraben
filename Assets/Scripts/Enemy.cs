﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature {
    
    // attributes
    public int damage = 10;
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
            case State.Retreating: Retreat();
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
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public virtual void Retreat(){
        state = State.BeingIdle;
    }
}
