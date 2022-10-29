using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Weapon"))
        {
            gameObject.GetComponent<AnimalHunger>().FeedAnimal();
            Destroy(other.gameObject);
        }
    }
}
