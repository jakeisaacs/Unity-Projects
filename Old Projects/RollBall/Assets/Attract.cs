using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour
{
    public float StrengthOfAttraction;
    GameObject box;
    // Start is called before the first frame update
    void Start()
    {

        box = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //magsqr will be the offset squared between the object and the planet
        float magsqr;

        //offset is the distance to the planet
        Vector3 offset;

        //get offset between each planet and the player
        offset = box.transform.position - transform.position;

        //My game is 2D, so  I set the offset on the Z axis to 0
        offset.y = 0;

        //Offset Squared:
        magsqr = offset.sqrMagnitude;

        //Check distance is more than 0 to prevent division by 0
        if (magsqr > 0.0001f && magsqr < 20)
        {
            //Create the gravity- make it realistic through division by the "magsqr" variable

            box.GetComponent<Rigidbody>().AddForce((StrengthOfAttraction * offset.normalized / (magsqr * .5f)) * box.GetComponent<Rigidbody>().mass);
        }
    }
}
