using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuer : Enemy
{
    
    // public float speed = 0.2f;
    // public Transform player;
    // public int threatDistance = 5;


    void FixedUpdate(){
        
        trigger();

    }

    public override void idle(){}
    public override void attack(){}
    public override void retreat(){}
}
