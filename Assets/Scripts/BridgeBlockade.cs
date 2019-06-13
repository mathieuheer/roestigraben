using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBlockade : MonoBehaviour, ITriggerable
{
    private Animator animator;
    private bool isActive = false;
    public bool IsActive
    {
        get { return isActive; }
        set
        {
            if (value) {
                animator.SetTrigger("Appear");
            }
            else
            {
                animator.SetTrigger("Disappear");
            }
            isActive = value;
            SoundManagerScript.PlaySound("bridgeBlockade");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
