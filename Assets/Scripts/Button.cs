using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public enum Type
    {
        Hold,
        Toggle,
        Timed
    }

    public Type buttonType = Type.Hold;
    public float onTime;

    public Sprite onSprite;
    public Sprite offSprite;
    public GameObject otherGameObject;

    private ITriggerable triggerable;
    private SpriteRenderer spriteRenderer;
    private float turnOffTime;
    private bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        triggerable = otherGameObject.GetComponentInChildren<ITriggerable>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if(buttonType == Type.Timed && timerIsRunning && turnOffTime < Time.time)
        {
            triggerable.IsActive = false;
            timerIsRunning = false;
            UpdateSprites();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (buttonType)
        {
            case Type.Hold:
                triggerable.IsActive = true;
                break;

            case Type.Toggle:
                triggerable.IsActive = !triggerable.IsActive;
                break;

            case Type.Timed:
                if(!timerIsRunning)
                    triggerable.IsActive = true;
                break;
        }

        UpdateSprites();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        switch (buttonType)
        {
            case Type.Hold:
                triggerable.IsActive = false;
                break;

            case Type.Toggle:
                break;

            case Type.Timed:
                if (!timerIsRunning && triggerable.IsActive)
                {
                    turnOffTime = Time.time + onTime;
                    timerIsRunning = true;
                }
                break;
        }

        UpdateSprites();
    }

    private void UpdateSprites()
    {
        if (triggerable.IsActive)
        {
            spriteRenderer.sprite = onSprite;
        }
        else
        {
            spriteRenderer.sprite = offSprite;
        }
    }
}
