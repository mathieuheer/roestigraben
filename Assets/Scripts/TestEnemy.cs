using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{

    public int health = 100;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
            Destroy(gameObject);
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 100, SendMessageOptions.DontRequireReceiver);
    }       
}
