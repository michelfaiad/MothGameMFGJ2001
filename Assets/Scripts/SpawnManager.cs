using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Editor Variables
    [Header("Spawn Config")]
    [SerializeField] float spawnRateBulb = 2f;
    [SerializeField] float spawnRatePowerup = 15f;
    [SerializeField] GameObject[] bulbs;
    [SerializeField] GameObject[] powerups;
    #endregion

    #region Private Variables
    bool canSpawnBulbs = true;
    bool canSpawnPowerups = true;
    float minY = -11f;
    float maxY = 11f;
    float maxX = 375f;
    float xPosOffset = 45f;
    #endregion

    #region Unity Methods
    void Start()
    {
        
    }

    void Update()
    {
        if (canSpawnBulbs) {
            int bulbsInScene = FindObjectsOfType<BulbBehaviour>().Length;

            if (bulbsInScene < GameParameters.inst.MaxSpawnedBulbs)
            {
                StartCoroutine(SpawnRandomBulb());
            }
        }
        if (canSpawnPowerups)
        {
            int powerupsInScene = FindObjectsOfType<PowerupController>().Length;

            if (powerupsInScene < GameParameters.inst.MaxSpawnedPowerups)
            {
                StartCoroutine(SpawnRandomPowerup());
            }
        }
        
    }
    #endregion

    #region Custom Methods
    IEnumerator SpawnRandomBulb()
    {
        canSpawnBulbs = false;

        int index = Random.Range(0, bulbs.Length);

        float playerPos = FindObjectOfType<MothController>().transform.position.x;

        if (playerPos + xPosOffset < maxX)
        {
            float yPos = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(playerPos + xPosOffset, yPos, 0f);

            Instantiate(bulbs[index], spawnPos, Quaternion.identity);
        }
        yield return new WaitForSeconds(spawnRateBulb);
        canSpawnBulbs = true;
    }

    IEnumerator SpawnRandomPowerup()
    {
        canSpawnPowerups = false;

        int index = Random.Range(0, powerups.Length);

        float playerPos = FindObjectOfType<MothController>().transform.position.x;

        //float yPos = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(playerPos + xPosOffset, minY, 0f);

        Instantiate(powerups[index], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(spawnRatePowerup);
        canSpawnPowerups = true;
    }
    #endregion
}
