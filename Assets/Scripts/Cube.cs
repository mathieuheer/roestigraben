using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, ITriggerable
{
    private Vector3 initPosition;
    private Animator animator;
    private bool isActive = false;
    public bool IsActive
    {
        get { return isActive; }
        set
        {
            if (value)
            {
                animator.SetTrigger("Despawn");
                SoundManagerScript.PlaySound("cubeRespawn");
            }
            isActive = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        animator = GetComponent<Animator>();
        animator.SetTrigger("Spawn");
    }

    public void OnDespawnAnimationEnd()
    {
        transform.position = initPosition;
        animator.SetTrigger("Spawn");
    }
}
