using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20f;
    private float spawnPosZ = 30f;

    private float spawnPosX = 22f;
    private float spawnLBZ = -10f;
    private float spawnUBZ = 0f;


    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalZAxis", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalXAxis", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimalZAxis()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalXAxis()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int randomSide = Random.Range(0, 2) * 2 - 1;
        Vector3 spawnPos = new Vector3(spawnPosX * randomSide, 0, Random.Range(spawnLBZ, spawnUBZ));
        Quaternion spawnRotation = Quaternion.Euler(animalPrefabs[animalIndex].transform.rotation.x,
            -90 * randomSide, animalPrefabs[animalIndex].transform.rotation.z);

        Instantiate(animalPrefabs[animalIndex], spawnPos, spawnRotation);
    }
}
