using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        //transform.position = new Vector3(3, 4, 1);
        //transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0f, 0f, 0f, 1f);
    }
    
    void Update()
    {
        //transform.Rotate(0f, 90f, 0f);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.Rotate(0f, -90f, 0f);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Rotate(0f, -90f, 0f);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.Rotate(90f, 0f, 0f);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            transform.Rotate(-90f, 0f, 0f);

        //transform.Rotate(20.0f * Time.deltaTime, 20.0f * Time.deltaTime, 0.0f);
    }

    IEnumerable RotateObject(float angle)
    {
        //Quaternion targetRotation = Quaternion.Euler(transform.rotation.x + angle, transform.rotation.y + angle, transform.rotation.z);

        //while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        //{
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 15);
        //    yield return null;
        //}

        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        yield return null;
    }
}
