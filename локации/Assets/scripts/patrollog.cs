using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrollog : MonoBehaviour
{
    public Transform[] patrolpoints;
    public float MOVESPEED;
    public int patroldestination;


    void Update()
    {
        if (patroldestination == 0) 
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[0].position, MOVESPEED * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolpoints[0].position) < .2f)
            {
                patroldestination = 1;
            }
        }
        if (patroldestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[1].position, MOVESPEED * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolpoints[1].position) < .2f)
            {
                patroldestination = 0;
            }
        }
    }
}
