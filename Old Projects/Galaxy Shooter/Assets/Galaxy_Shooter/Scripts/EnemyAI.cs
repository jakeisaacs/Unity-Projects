using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private GameObject _explosionPrefab;

    private UIManager _scoreUpdate;

    // Start is called before the first frame update
    void Start()
    {
        _scoreUpdate = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {

        float x = transform.position.x;
        float y = transform.position.y;

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (y < -5)
        {
            transform.position = new Vector3(Random.Range(-7, 7), 5f, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            DestroyShip();
        }
        else if (collision.tag == "laser")
        {
            if (collision.transform.parent != null)
                Destroy(collision.transform.parent.gameObject);
            else
               Destroy(collision.gameObject);

            DestroyShip();
        }

    }

    private void DestroyShip()
    {
        if(_scoreUpdate != null)
        {
            _scoreUpdate.UpdateScore();
        }
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
