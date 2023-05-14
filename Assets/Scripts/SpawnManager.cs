using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // These are used for the TimerAlternative() function
    public  float timer = 1.5f;
    private float timerMin = 1.0f; 
    private float timerMax = 2.0f;

//---------------------------------------------------------

    public GameObject[] animalPrefabs;
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;

    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
        InvokeRepeating("SpawnLeftAnimal", 2, 3.0f);
        InvokeRepeating("SpawnRightAnimal", 2, 4.0f);
    }

    // Custom function
    void SpawnRandomAnimal()
    {
        // Randomly generate animal Index and spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

       void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }


    // Second custom function that is optional
    void TimerAlternative()
    {
        // A different way to make a timer to spawn the animals at random intervals
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = Random.Range(timerMin, timerMax);
            SpawnRandomAnimal();
        }
    }

}
