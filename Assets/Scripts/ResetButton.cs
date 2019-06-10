using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResetButton : MonoBehaviour, ITrigger
{
    public enum Type
    {
        Toggle
    }

    public Type buttonType = Type.Toggle;

    public Sprite onSprite;
    public Sprite offSprite;
    public GameObject[] triggerableObjects;
    private Vector3[] origPositions;

    private bool isOn = false;

    public bool IsOn
    {
        get { return isOn; }
        set
        {
            isOn = value;
            for (var i = 0; i < triggerableObjects.Length; i++)
            {

                triggerableObjects[i].transform.position = origPositions[i];
            }
        }
    }

    private ITriggerable[] triggerables;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        origPositions = new Vector3[triggerableObjects.Length];
        triggerables = new ITriggerable[triggerableObjects.Length];
        for(var i=0; i<triggerableObjects.Length; i++)
        {
            triggerables[i] = triggerableObjects[i].GetComponentInChildren<ITriggerable>();
            origPositions[i] = triggerableObjects[i].transform.position;
        }
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsOn = true;

        UpdateSprites();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsOn = false;

        UpdateSprites();
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
