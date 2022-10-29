using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyShipPrefab;
    [SerializeField]
    private GameObject[] _powerups;
    [SerializeField]
    private GameObject _player;
    private bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {

    }


    IEnumerator spawnEnemy()
    {
        while (canSpawn)
        {
            Instantiate(_enemyShipPrefab, new Vector3(Random.Range(-7, 7), 6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator spawnPowerups()
    {
        while (canSpawn)
        {
            int rand = Random.Range(0, 3);
            Instantiate(_powerups[rand], new Vector3(Random.Range(-7, 7), 6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }

    public void StopSpawn()
    {
        canSpawn = false;
    }
  
    public void StartSpawn()
    {
        canSpawn = true;
        StartCoroutine(spawnEnemy());
        StartCoroutine(spawnPowerups());
    }
}
