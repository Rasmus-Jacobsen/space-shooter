using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour
{
    [Header("Spawn setup")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;          // assign empty GameObjects in the scene (top of screen)

    [Header("Wave settings")]
    public int enemiesPerWave = 5;
    public float timeBetweenSpawns = 1f;
    public float timeBetweenWaves = 4f;
    public float difficultyRamp = 1.1f;     // >1.0 increases difficulty over time
    public bool startOnAwake = true;

    int currentWave = 0;
    bool running = false;

    void Start()
    {
        if (startOnAwake) StartSpawner();
    }

    public void StartSpawner()
    {
        if (running) return;
        if (enemyPrefab == null)
        {
            Debug.LogError($"{name}: enemyPrefab is not assigned.");
            return;
        }

        running = true;
        StartCoroutine(SpawnWaves());
    }

    public void StopSpawner()
    {
        running = false;
        StopAllCoroutines();
    }

    IEnumerator SpawnWaves()
    {
        while (running)
        {
            currentWave++;
            int toSpawn = Mathf.Max(1, Mathf.CeilToInt(enemiesPerWave * Mathf.Pow(difficultyRamp, currentWave - 1)));

            for (int i = 0; i < toSpawn && running; i++)
            {
                SpawnOne();
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            // wait between waves
            float wait = timeBetweenWaves;
            while (wait > 0f && running)
            {
                wait -= Time.deltaTime;
                yield return null;
            }
        }
    }

    void SpawnOne()
    {
        Transform sp = (spawnPoints != null && spawnPoints.Length > 0)
            ? spawnPoints[Random.Range(0, spawnPoints.Length)]
            : transform;

        Instantiate(enemyPrefab, sp.position, sp.rotation);
    }
}