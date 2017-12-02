using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;

    private Rigidbody2D rb2d;
    private BoxCollider2D collider;
    private bool isgrounded = true;
    private float distToGround;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        distToGround = collider.bounds.extents.y;
    }

    void Update()
    {
        movePlayer(); 
    }

    void movePlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            rb2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(
                -speed,
                rb2d.velocity.y
                );
            //rb2d.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
        }
        else
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(
                speed,
                rb2d.velocity.y
                );
        }
        else
        {
            rb2d.velocity = new Vector2(
                0,
                rb2d.velocity.y
                );
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.5f);
    }

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.gameObject.name == "foreground")
    //    {
    //        isgrounded = true;
    //        rb2d.gravityScale = 0;
    //    }
    //}

    ////consider when character is jumping .. it will exit collision.
    //void OnCollisionExit(Collision theCollision)
    //{
    //    if (theCollision.gameObject.name == "foreground")
    //    {
    //        isgrounded = false;
    //    }
    //}

}
