using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerHitSound, enemyDeathSound, collectKeySound, useKeySound, bridgeSound, cubeRespawnSound, slay, rewardSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        enemyDeathSound = Resources.Load<AudioClip>("enemyHit");
        playerHitSound = Resources.Load<AudioClip>("hit");
        collectKeySound = Resources.Load<AudioClip>("collectKey");
        bridgeSound = Resources.Load<AudioClip>("bridgeBlockade");
        cubeRespawnSound = Resources.Load<AudioClip>("cubeRespawn");
        useKeySound = Resources.Load<AudioClip>("useKey");
        slay = Resources.Load<AudioClip>("slay");
        rewardSound = Resources.Load<AudioClip>("rewardSound");
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
            case "collectKey":
                audioSrc.PlayOneShot(collectKeySound);
                break;
            case "bridgeBlockade":
                audioSrc.PlayOneShot(bridgeSound);
                break;
            case "cubeRespawn":
                audioSrc.PlayOneShot(cubeRespawnSound);
                break;
            case "useKey":
                audioSrc.PlayOneShot(useKeySound);
                break;
            case "slay":
                audioSrc.PlayOneShot(slay);
                break;
            case "reward":
                audioSrc.PlayOneShot(rewardSound);
                break;
        }
    }
}
