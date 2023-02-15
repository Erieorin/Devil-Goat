using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rd;
    public Animator animator;
    public vectorvalue startingPosition;

    Vector2 movement;
    void Start()
    {
        transform.position = startingPosition.initialValue;

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }


    void FixedUpdate()
    {
        rd.MovePosition(rd.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
