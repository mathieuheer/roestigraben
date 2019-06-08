using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Keyhole : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closedSprite;
    public GameObject[] triggerableObjects;

    private bool isOpen = false;
    private bool IsOpen
    {
        get { return isOpen; }
        set
        {
            isOpen = value;
            foreach (var t in triggerables)
            {
                if (t is ITriggerable)
                {
                    t.IsActive = isOpen;
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

    // Start is called before the first frame update
    void Start()
    {
        triggerables = new ITriggerable[triggerableObjects.Length];
        for (var i = 0; i < triggerableObjects.Length; i++)
        {
            triggerables[i] = triggerableObjects[i].GetComponentInChildren<ITriggerable>();
        }
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsOpen) return;

        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            if(player.numOfKeys > 0)
            {
                player.UseKey();
                IsOpen = true;
                UpdateSprites();
            }
        }
    }


    private void UpdateSprites()
    {
        if (IsOpen)
        {
            spriteRenderer.sprite = openSprite;
        }
        else
        {
            spriteRenderer.sprite = closedSprite;
        }
    }
}
