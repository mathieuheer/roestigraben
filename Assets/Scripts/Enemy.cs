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
        if ((player.transform.position - transform.position).magnitude <= threatDistance)
        {
            Vector2 direction = player.transform.position - transform.position;

            LayerMask layerMask = LayerMask.GetMask("Enemy");
            int mask = layerMask.value;
            mask = ~mask;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, mask, Mathf.NegativeInfinity, Mathf.Infinity);
            Debug.DrawRay(transform.position, direction, Color.magenta, 2);

            Debug.Log("NULL? - " + (hit.collider != null));
            Debug.Log("Player? - " + (hit.collider == player));
            Debug.Log("Tag - " + hit.collider.tag);
            if (hit.collider != null && hit.collider.tag == player.tag)
            {
                state = State.Approaching;
            }
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
