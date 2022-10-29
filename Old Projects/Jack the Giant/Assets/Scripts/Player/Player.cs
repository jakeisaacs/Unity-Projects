using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f, maxVelocity = 8f;

    private Rigidbody2D playerBody;
    private Animator anim;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0.0f;
        float vel = Mathf.Abs(playerBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

 //      Debug.Log(vel);
        if(h>0)
        {
            if (vel < maxVelocity)
                forceX = speed;

            this.transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 1, 0));
            anim.SetBool("Walk", true);
        }
        else if(h<0)
        {

            if (vel < maxVelocity)
                forceX = -speed;

            this.transform.rotation = Quaternion.AngleAxis(180,new Vector3(0,1,0));
            anim.SetBool("Walk", true);

        }
        else
        {
            anim.SetBool("Walk",false);
        }

        playerBody.AddForce(new Vector2(forceX, 0));
    }
}
