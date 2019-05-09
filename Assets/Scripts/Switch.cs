using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool On = false;
    public GameObject otherGameObject;

    private ITriggerable triggerable;

    // Start is called before the first frame update
    void Start()
    {
        triggerable = otherGameObject.GetComponentInChildren<ITriggerable>();
    }

    // Update is called once per frame
    void Update()
    {
        triggerable.IsActive = On;
    }
}
