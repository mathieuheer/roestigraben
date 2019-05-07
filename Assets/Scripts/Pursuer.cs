using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuer : Enemy
{

    void FixedUpdate(){
        Trigger();
        IsALive();
    }

}
