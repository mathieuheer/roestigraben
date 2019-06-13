using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Creature : MonoBehaviour
{
    public int health = 100;
    public float speed = 6;

    public Sprite frontFacing;
    public Sprite backFacing;
    public Sprite leftFacing;
    public Sprite rightFacing;

    protected MoveDirection moveDirection = MoveDirection.Down;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected bool isAttacking = false;

    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = frontFacing;
    }

    public void Move(Vector3 direction)
    {
        SetDirection(direction);
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    protected void SetDirection(Vector3 direction)
    {
        direction = direction.normalized;

        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {
            moveDirection = (direction.x < 0) ? MoveDirection.Left : MoveDirection.Right;
        }
        else
        {
            moveDirection = (direction.y < 0) ? MoveDirection.Down : MoveDirection.Up;
        }
        UpdateSprite();
    }

    void UpdateSprite()
    {
        if (!isAttacking)
        {
            switch (moveDirection)
            {
                case MoveDirection.Up:
                    spriteRenderer.sprite = backFacing;
                    break;

                case MoveDirection.Down:
                    spriteRenderer.sprite = frontFacing;
                    break;

                case MoveDirection.Left:
                    spriteRenderer.sprite = leftFacing;
                    break;

                case MoveDirection.Right:
                    spriteRenderer.sprite = rightFacing;
                    break;
            }
        }
    }

    protected virtual void TakeDamage(int damage)
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

    void GetKnockedBack(Vector3 direction)
    {
        direction.Normalize();

        //Layer mask to check hit-detection only with map (layer 11)
        int layerMask = 1 << 11;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + direction, direction, 1, layerMask);

        if (hit.collider == null)
            transform.Translate((Vector2)direction);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
