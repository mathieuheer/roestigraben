using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ITriggerable
{
    private bool isActive = false;
    public bool IsActive
    {
        get { return isActive; }
        set
        {
            this.gameObject.SetActive(!value);
            isActive = value;
        }
    }

}
