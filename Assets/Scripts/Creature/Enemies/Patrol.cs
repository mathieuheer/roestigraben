using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Enemy
{
    public bool circle = false;
    public Transform[] waypoints;
    int index = 0;
    bool up = true;

    void FixedUpdate()
    {
        HandleState();
    }

    public override void Approach()
    {
        index = getNearestWaypoint();
        if ((waypoints[index].transform.position - transform.position).magnitude >= threatDistance || player.health <= 0)
        {
            state = State.Retreating;
            return;
        }
        direction = player.transform.position - transform.position;
        Move(direction);
    }

    public override void Retreat()
    {
        index = getNearestWaypoint();
        direction = waypoints[index].transform.position - transform.position;
        if ((direction).magnitude < 0.1)
        {
            state = State.BeingIdle;
            return;
        }
        Move(direction);
    }

    public override void Idle(){
        base.Idle();
        if (state != State.BeingIdle) return;

        direction = waypoints[index].transform.position - transform.position;
        Move(direction);

        if ((direction).magnitude < 0.1)
        {
            if (circle)
            {
                if (index == waypoints.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            else
            {
                if (index == waypoints.Length - 1)
                {
                    up = false;
                    index--;
                }
                else if (index == 0)
                {
                    up = true;
                    index++;
                }
                else if (up)
                {
                    index++;
                }
                else
                {
                    index--;
                }
            }
        }
    }

    int getNearestWaypoint()
    {
        int index = 0;
        for (int i = 0; i < waypoints.Length; i++)
        {
            if ((waypoints[i].transform.position - transform.position).magnitude < (waypoints[index].transform.position - transform.position).magnitude)
            {
                index = i;
            }
        }
        return index;
    }

}
