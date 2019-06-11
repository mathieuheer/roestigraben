using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour, ITrigger
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
    public GameObject[] triggerableObjects;

    private bool isOn = false;

    public bool IsOn
    {
        get { return isOn; }
        set
        {
            isOn = value;
            foreach (var t in triggerables)
            {
                if(t is ITriggerable)
                {
                    t.IsActive = isOn;
                }
                else
                {
                    Debug.LogAssertion("Element " + Array.IndexOf(triggerables, t) + " is not ITriggerable");
                }
            }
        }
    }

    private ITriggerable[] triggerables;
    private SpriteRenderer spriteRenderer;
    private float turnOffTime;
    private bool timerIsRunning = false;
    private GameObject trigger = null;

    // Start is called before the first frame update
    void Start()
    {
        triggerables = new ITriggerable[triggerableObjects.Length];
        for(var i=0; i<triggerableObjects.Length; i++)
        {
            triggerables[i] = triggerableObjects[i].GetComponentInChildren<ITriggerable>();
        }
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if(buttonType == Type.Timed && timerIsRunning && turnOffTime < Time.time)
        {
            IsOn = false;
            timerIsRunning = false;
            UpdateSprites();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(trigger == null)
        {
            trigger = collision.gameObject;
            switch (buttonType)
            {
                case Type.Hold:
                    IsOn = true;
                    break;

                case Type.Toggle:
                    IsOn = !IsOn;
                    break;

                case Type.Timed:
                    if (!timerIsRunning)
                        IsOn = true;
                    break;
            }

            UpdateSprites();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(trigger != null && trigger == collision.gameObject)
        {
            trigger = null;
            switch (buttonType)
            {
                case Type.Hold:
                    IsOn = false;
                    break;

                case Type.Toggle:
                    break;

                case Type.Timed:
                    if (!timerIsRunning && IsOn)
                    {
                        turnOffTime = Time.time + onTime;
                        timerIsRunning = true;
                    }
                    break;
            }

            UpdateSprites();
        }
    }

    private void UpdateSprites()
    {
        if (IsOn)
        {
            spriteRenderer.sprite = onSprite;
        }
        else
        {
            spriteRenderer.sprite = offSprite;
        }
    }
}
