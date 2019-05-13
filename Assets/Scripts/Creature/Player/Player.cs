using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Player : Creature
{

    public int maxHealth; 
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public TextMeshProUGUI text;
    int numOfKeys = 0;

    public virtual void Awake(){
        maxHealth = health;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        HandleMelee();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        MoveCamera();
    }

    void Move()
    {
        Vector2 direction = Vector2.zero;

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
            SetDirection(direction);
            transform.Translate(direction.normalized * speed * Time.deltaTime);
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

    protected override void TakeDamage(int damage){
        base.TakeDamage(damage);
        UpdateHearts();

    }

    private void UpdateHearts(){
        int fullHeartsLeft = health/(maxHealth/hearts.Length);
        for (int i = 0; i < fullHeartsLeft; i++)
        {
            hearts[i].enabled = true;
            hearts[i].sprite = fullHeart; 
        }
        if(health%(maxHealth/hearts.Length) != 0){
            hearts[fullHeartsLeft].enabled = true;
            hearts[fullHeartsLeft].sprite = halfHeart;
        }else{
            hearts[fullHeartsLeft].enabled = false;
        }
        for (int i = fullHeartsLeft+1; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }
    }

    private void AddKey(){
        numOfKeys++;
        text.SetText(numOfKeys.ToString());
    }

    private void UseKey(){
        if(numOfKeys > 0){
            numOfKeys--;
            text.SetText(numOfKeys.ToString());
        }
    }


}
