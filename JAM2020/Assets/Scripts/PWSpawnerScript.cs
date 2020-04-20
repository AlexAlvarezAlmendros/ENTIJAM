using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWSpawnerScript : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    private PowerUpScript powerUpScript;

    public float maxDelay;
    public float minDelay;

    public float FirstSpawn = 0f;
    private float nextSpawn = 0f;

    public int whatToSpawn;
    public float whereToSpawn;
    public float whenToSpawn;

    void Start()
    {
        nextSpawn = FirstSpawn;
    }

    void Update()
    {
        if (Time.time > nextSpawn) // if time has come
        {
            whatToSpawn = Random.Range(1, 5); //define random value between 1 and 4 (5 is ecluded)

            whereToSpawn = Random.Range(0, 5); // define random value between 0 and 4 (5 is excluded)

            whenToSpawn = Random.Range(minDelay, maxDelay); // define random time value to spawn

            if (whatToSpawn == 1)
            {
                GameObject powerSpawned = Instantiate(PowerUpPrefab, new Vector3(-5.5f, whereToSpawn, 1f), Quaternion.identity);
                powerUpScript = powerSpawned.GetComponent<PowerUpScript>();
                //powerUpScript.powerUpType = powerUpType.ChangeScene;
            }
            else if (whatToSpawn == 2)
            {
                GameObject powerSpawned = Instantiate(PowerUpPrefab, new Vector3(-5.5f, whereToSpawn, 1f), Quaternion.identity);
                powerUpScript = powerSpawned.GetComponent<PowerUpScript>();
                //powerUpScript.powerUpType = powerUpType.Shield;
            }
            else if (whatToSpawn == 3)
            {
                GameObject powerSpawned = Instantiate(PowerUpPrefab, new Vector3(-5.5f, whereToSpawn, 1f), Quaternion.identity);
                powerUpScript = powerSpawned.GetComponent<PowerUpScript>();
                //powerUpScript.powerUpType = powerUpType.PW3;
            }
            else if (whatToSpawn == 4)
            {
                GameObject powerSpawned = Instantiate(PowerUpPrefab, new Vector3(-5.5f, whereToSpawn, 1f), Quaternion.identity);
                powerUpScript = powerSpawned.GetComponent<PowerUpScript>();
                //powerUpScript.powerUpType = powerUpType.PW4;
            }
            //else if (whereToSpawn == 5)
            //{
            //    GameObject powerSpawned = Instantiate(PowerUpPrefab, new Vector3(-5.5f, whereToSpawn, 1f), Quaternion.identity);
            //    powerUpScript = powerSpawned.GetComponent<PowerUpScript>();
            //    //powerUpScript.powerUpType = powerUpType.;
            //}
            //else if (whatToSpawn == 6)
            //{
            //    GameObject powerSpawned = Instantiate(PowerUpPrefab, new Vector3(-5.5f, whereToSpawn, 1f), Quaternion.identity);
            //    powerUpScript = powerSpawned.GetComponent<PowerUpScript>();
            //    //powerUpScript.powerUpType = powerUpType.;
            //}

            nextSpawn = Time.time + whenToSpawn;
        }
    }
}
