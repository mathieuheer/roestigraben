using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {

    }

    Vector2 direction = Vector2.zero;
    public float speed = 0.3f;

    // shooting
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Update()
    {
        GetDirection();
        Move();
        //Shoot();
    }


    void MoveCamera()
    {
        // http://answers.unity.com/answers/1290524/view.html
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = transform.position;
        var c = (mousePosition + playerPosition) / 2;
        Camera.main.transform.position = (playerPosition + c) / 2 + new Vector3(0, 0, -1); ;

    }

    private Vector3 mousePosition;
    private Vector3 playerPosition;
    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        MoveCamera();
    }

    void GetDirection()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    void Move()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;
    int destroyTime = 5;
    
    void Shoot()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(firePoint.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        firePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetButtonDown("Fire1")){
            // Destroy after time
            GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(bulletObject, destroyTime); 
        }
    }
    

}
