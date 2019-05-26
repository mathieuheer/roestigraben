using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerWalkSound, playerHitSound, enemyDeathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerWalkSound = Resources.Load<AudioClip>("walk");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        switch (clip)
        {
            case "walk":
                audioSrc.PlayOneShot(playerWalkSound);
                break;
        }
    }
}
