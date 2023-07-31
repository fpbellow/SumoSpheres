using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private GameObject playerObject;
    private PlayerController playerScr;

    private float spawnRange = 8f;
    public int waveNumber = 0;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        playerScr = playerObject.GetComponent<PlayerController>();
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void WaveEndCheck()
    {
        enemyCount = FindObjectsOfType<EnemyMove>().Length;
        if (enemyCount == 0)
        {
            waveNumber += 1;
            SpawnEnemyWave(waveNumber);
            StartCoroutine(PowerUpSpawnTimeRoutine(waveNumber));
        }
    }


    void SpawnEnemyWave(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    IEnumerator PowerUpSpawnTimeRoutine(int enemyNum)
    {
        int spawnWaitTime = Random.Range(1, enemyNum);
        yield return new WaitForSeconds(spawnWaitTime);
        if(playerScr.hasPowerUp == true)
        {
            Debug.Log("already powered up");
            yield return new WaitForSeconds(7);
        }
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }
}
