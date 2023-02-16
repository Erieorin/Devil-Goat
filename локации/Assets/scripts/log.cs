using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : enemy
{
    private Rigidbody2D myrigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    void Start()
    {
        currentstate = EnemyState.idle;
        myrigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if ((Vector3.Distance(target.position, transform.position) <= chaseRadius) && (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            if(currentstate == EnemyState.idle || currentstate == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
                myrigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
           
        }
    }
    private void ChangeState(EnemyState newState)
    {
        if(currentstate != newState)
        {
            currentstate = newState;
        }
    }
}
