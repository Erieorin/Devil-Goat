using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : enemy
{
    public BoxCollider2D gm;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    private Rigidbody2D rd;

    private Vector2 movement;

    public LayerMask whatIsPlayer;

    public bool shouldRotate;

    private bool isinchaserange;
    private bool isinattackrange;
    public Vector3 dir;
    public playermovement kek;

    public Transform[] patrolpoints;
    public int patroldestination;

    public float sped;
    public float speed;

    public playermovement lol;



    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        gm = GetComponent<BoxCollider2D>();
        //GameObject.DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        anim.SetBool("wakeUp", isinchaserange);

        isinchaserange = Physics2D.OverlapCircle(transform.position, chaseRadius, whatIsPlayer);
        isinchaserange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        if (shouldRotate)
        {
            anim.SetFloat("horizontal", dir.x);
            anim.SetFloat("vertical", dir.y);
        }
        if (lol.hiding)
        {
            gm.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gm.GetComponent<BoxCollider2D>().enabled = true;
        }

    }
    private void FixedUpdate()
    {

        if (isinchaserange && !isinattackrange && !kek.hiding)
        {
            MoveCharacter(movement);
        }
        else
        {
            if (patroldestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolpoints[0].position, sped * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolpoints[0].position) < .2f)
                {
                    patroldestination = 1;
                }
            }
            if (patroldestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolpoints[1].position, sped * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolpoints[1].position) < .2f)
                {
                    patroldestination = 2;
                    anim.Play("goatleft");
                }
            }
            if (patroldestination == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolpoints[2].position, sped * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolpoints[2].position) < .2f)
                {
                    patroldestination = 0;
                    anim.Play("goatleft");
                }
            }
        }
        if (isinattackrange)
        {
            rd.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rd.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

}
