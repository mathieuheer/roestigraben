using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIntroDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private bool dialogue = false;
    public float targetTime = 1f;

    void Update()
    {

        targetTime -= Time.deltaTime;

        if (!dialogue && targetTime <= 0.0f)
        {
            dialogue = true;
            TimerEnded();
        }

    }

    void TimerEnded()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

}
