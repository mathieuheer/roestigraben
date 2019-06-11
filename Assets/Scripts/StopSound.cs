using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var audio = gameObject.GetComponentInParent<AudioSource>();
        audio.Stop();
    }
}
