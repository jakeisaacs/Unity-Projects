using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
       
        if (transform.position.y > 5.4)
        {
            if (transform.parent != null)
                Destroy(transform.parent.gameObject);
            Destroy(this.gameObject); 
        }
    }
}
