using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    
    // attributes
    public int health = 100;
    public int damage = 10;
    public float speed = 5f;
    public bool isMelee = false;
    public float attackRange = 10;
    public float threatDistance = 15;
    public Transform player;

    // methodes
    public abstract void idle();

    public void approach(){
        Vector3 direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public void trigger(){
        if((player.transform.position - transform.position).magnitude < threatDistance){
            approach();
        }
    }

    public abstract void attack();
    public abstract void retreat();
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("DAMAGE");
    }
    public void DoDamage(int damage)
    {
        health -= damage;
        Debug.Log("DAMAGE");
    }


}
