using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float spaceTimer;
    private float minSpaceTime = 1f;

    private void Start()
    {
        spaceTimer = 0f;
    }


    // Update is called once per frame
    void Update()
    {
        spaceTimer += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && spaceTimer >= minSpaceTime)
        { 
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            spaceTimer = 0f;
        }
    }
}
