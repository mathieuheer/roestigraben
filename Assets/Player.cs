using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        
    }

    Vector2 direction = Vector2.zero;
    [SerializeField]
    private float speed = 0.3f;

    void Update()
    {
        GetDirection();
        Move();
    }

    void GetDirection()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
        }
    }

    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
