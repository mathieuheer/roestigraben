using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    public GameObject[] triggerObjects;
    public GameObject triggerableObject;

    private ITrigger[] triggers;
    private ITriggerable triggerable;
    void Start()
    {
        triggers = new ITrigger[triggerObjects.Length];
        for (var i = 0; i < triggerObjects.Length; i++)
        {
            triggers[i] = triggerObjects[i].GetComponentInChildren<ITrigger>();
        }

        triggerable = triggerableObject.GetComponentInChildren<ITriggerable>();
    }

    void Update()
    {
        bool activated = true;
        foreach (var t in triggers)
        {
            activated = t.IsOn;
            if (!activated) break;
        }
        triggerable.IsActive = activated;
    }
}
