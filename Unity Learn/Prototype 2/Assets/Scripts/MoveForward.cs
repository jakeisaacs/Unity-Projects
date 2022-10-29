using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40f;

    public char axisChar = 'z';

    private Vector3 forwardAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (axisChar)
        {
            case 'x':
                forwardAxis = Vector3.right;
                break;
            case 'y':
                forwardAxis = Vector3.up;
                break;
            case 'z':
                forwardAxis = Vector3.forward;
                break;
            default:
                forwardAxis = Vector3.forward;
                break;
        }

        transform.Translate(forwardAxis * Time.deltaTime * speed);
    }
}
