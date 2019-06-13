using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public int health = 100;


    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    protected void TakeDamage(int damage)
    {
        health -= damage;
        spriteRenderer.color = Color.red;

        if (health <= 0)
            Die();

        Invoke("ResetColor", 0.2f);
    }

    void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }

    protected virtual void Die()
    {
        Drop();
        Destroy(gameObject);
    }

    public GameObject droppableItem = null;

    public void Drop()
    {
        if (droppableItem != null)
        {
            var droppedItem = Instantiate(droppableItem, this.transform.position, Quaternion.identity, this.transform.parent);
        }
    }
}
