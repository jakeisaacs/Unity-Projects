using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber;

    private float speed = 20.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        print(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNumber == 1)
        {
            MovePlayer1();
        }
        else if (playerNumber == 2)
        {
            MovePlayer2();
        }
    }

    void MovePlayer1()
    {
        //Get user horizontal input
        horizontalInput = Input.GetAxis("leftright");
        forwardInput = Input.GetAxis("updown");

        //Move vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }

    void MovePlayer2()
    {
        //Get user horizontal input
        horizontalInput = Input.GetAxis("AD");
        forwardInput = Input.GetAxis("WS");

        //Move vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
