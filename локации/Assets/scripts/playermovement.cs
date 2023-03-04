using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public vectorvalue startingPosition;

    private bool canHide = false;
    public bool hiding = false;
    private SpriteRenderer rend;

    Vector2 movement;
    void Start()
    {
        transform.position = startingPosition.initialValue;
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        if (canHide && Input.GetKey("q"))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            rend.sortingOrder = -1;
            hiding = true;
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            rend.sortingOrder = 2;
            hiding = false;
        }
    }


    void FixedUpdate()
    {
        if (!hiding)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        else
            rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("hide"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("hide"))
        {
            canHide = false;
        }
    }
}
