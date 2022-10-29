using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public Camera rearViewCamera;
    public Camera frontViewCamera;
    public Camera firstPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        rearViewCamera.enabled = true;
        frontViewCamera.enabled = false;
        firstPersonCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rearViewCamera.enabled = true;
            frontViewCamera.enabled = false;
            firstPersonCamera.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rearViewCamera.enabled = false;
            frontViewCamera.enabled = true;
            firstPersonCamera.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rearViewCamera.enabled = false;
            frontViewCamera.enabled = false;
            firstPersonCamera.enabled = true;
        }

    }
}
