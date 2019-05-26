using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Creature
{

    static AudioSource audioSrc;

    // for audio
    new void Start()
    {
        base.Start();
        audioSrc = GetComponent<AudioSource>();
    }

    // for audio
    new void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        SoundManagerScript.PlaySound("hit");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetUserInput();
        HandleMelee();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        MoveCamera();
    }

    void GetUserInput()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        else
        {
            audioSrc.Stop();
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        if (!direction.Equals(Vector2.zero))
        {
            Move(direction);
        }
    }

    void HandleMelee()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isAttacking)
            {
                switch (moveDirection)
                {
                    case MoveDirection.Up:
                        animator.SetTrigger("Attack_Up");
                        break;

                    case MoveDirection.Down:
                        animator.SetTrigger("Attack_Down");
                        break;

                    case MoveDirection.Left:
                        animator.SetTrigger("Attack_Left");
                        break;

                    case MoveDirection.Right:
                        animator.SetTrigger("Attack_Right");
                        break;
                }

                isAttacking = true;
            }
        }
    }

    void MeeleAnimationEnd()
    {
        isAttacking = false;
    }

    void MoveCamera()
    {
        Vector3 playerPosition = transform.position;
        Camera.main.transform.position = playerPosition + new Vector3(0, 0, -1);
    }
}
