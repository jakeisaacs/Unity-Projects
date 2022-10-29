using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public float speed = 3f, maxVelocity = 8f;

    private Rigidbody2D playerBody;
    private Animator anim;

    private bool moveLeft, moveRight;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveLeft)
            MoveLeft();
        else if (moveRight)
            MoveRight();
    }

    public void SetMoveLeft(bool left)
    {
        moveLeft = left;
        moveRight = !left;
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("Walk", false);
    }

    void MoveLeft()
    {
        float forceX = 0.0f;
        float vel = Mathf.Abs(playerBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (vel < maxVelocity)
            forceX = -speed;

        Vector3 temp = transform.localScale;
        temp.x = -1f;
        transform.localScale = temp;

        anim.SetBool("Walk", true);

        playerBody.AddForce(new Vector2(forceX, 0));

    }

    void MoveRight()
    {
        float forceX = 0.0f;
        float vel = Mathf.Abs(playerBody.velocity.x);

        if (vel < maxVelocity)
            forceX = speed;

        Vector3 temp = transform.localScale;
        temp.x = 1f;
        transform.localScale = temp;

        anim.SetBool("Walk", true);

        playerBody.AddForce(new Vector2(forceX, 0));
    }
}
