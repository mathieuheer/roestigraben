using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{

    public float speed = 0.2f;
    public Transform player;
    public int threatDistance = 5;
    public int space = 6;
    public Vector3 guardPoint;
    public bool goBack = false;

    void Awake(){
         guardPoint = transform.position;
    }

    void FixedUpdate(){
        

        if((player.transform.position - transform.position).magnitude < threatDistance &&
            (transform.position - guardPoint).magnitude < space && !goBack){

            follow();
         
        }else if((guardPoint - transform.position).magnitude > 0.1 ){
            backToguardPoint();
        }


    }

    void follow(){
        if((transform.position - guardPoint).magnitude >= space -0.1){
            goBack = true;
        }
        Vector3 direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    void backToguardPoint(){
        Vector3 direction = guardPoint - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        if((guardPoint - transform.position).magnitude < 0.1){
            goBack = false;
        }
    }


}
