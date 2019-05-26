using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerHitSound, enemyDeathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        enemyDeathSound = Resources.Load<AudioClip>("enemyHit");
        playerHitSound = Resources.Load<AudioClip>("hit");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        switch (clip)
        {
            case "hit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
        }
    }
}
