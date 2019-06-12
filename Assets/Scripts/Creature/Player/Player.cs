using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class Player : Creature
{
    
    public int maxHealth; 
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public TextMeshProUGUI text;
    public int numOfKeys = 0;
    public bool hasSword = false;
    Vector3 respawnPoint;

    static AudioSource audioSrc;

    // for audio
    new void Start()
    {
        respawnPoint = transform.position;
        base.Start();
        audioSrc = GetComponent<AudioSource>();
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

        // walk sound

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
            SetDirection(direction);
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    void HandleMelee()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && hasSword)
        {
            if (!isAttacking)
            {
                SoundManagerScript.PlaySound("slay");
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

    new void TakeDamage(int damage){
        base.TakeDamage(damage);
        UpdateHearts();
        SoundManagerScript.PlaySound("hit");
    }

    protected override void Die(){

        GetComponent<Renderer>().enabled = false;
        this.gameObject.SetActive(false);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void UpdateHearts(){
        if(health == maxHealth){
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].enabled = true;
                hearts[i].sprite = fullHeart; 
            }
        }else if(health > 0){
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
        }else{
            for (int i = 0; i < hearts.Length; i++)
            {
                 hearts[i].enabled = false;
            }
        }
    }

    public void CollectKey(){
        numOfKeys++;
        text.SetText(numOfKeys.ToString());
        SoundManagerScript.PlaySound("collectKey");
    }

    public void CollectSword()
    {
        hasSword = true;
        SoundManagerScript.PlaySound("collectKey");
    }

    public void UseKey(){
        if(numOfKeys > 0){
            numOfKeys--;
            text.SetText(numOfKeys.ToString());
        }
    }

}
