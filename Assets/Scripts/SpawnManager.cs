using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Editor Variables
    [Header("Spawn Config")]
    [SerializeField] float spawnRate = 2f;
    [SerializeField] GameObject[] bulbs;
    #endregion

    #region Private Variables
    bool canSpawn = true;
    float minY = -11f;
    float maxY = 11f;
    float xPosOffset = 45f;
    #endregion

    #region Unity Methods
    void Update()
    {
        if (canSpawn) {
            int bulbsInScene = FindObjectsOfType<BulbBehaviour>().Length;

            if (bulbsInScene < GameParameters.inst.MaxSpawnedBulbs)
            {
                StartCoroutine(SpawnRandomBulb());
            }
        }
        
    }
    #endregion

    #region Custom Methods
    IEnumerator SpawnRandomBulb()
    {
        canSpawn = false;

        int index = Random.Range(0, bulbs.Length);

        float playerPos = FindObjectOfType<MothController>().transform.position.x;

        float yPos = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(playerPos + xPosOffset, yPos, 0f);

        Instantiate(bulbs[index], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }
    #endregion
}
