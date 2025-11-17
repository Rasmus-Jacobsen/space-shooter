using System.Collections;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner5;
    

    // Enemy prefab (must have tag "Enemy")
    public GameObject enemy;

    // Wave settings
    [SerializeField] public int enemiesPerWave = 5;
    public float spawnInterval = 0.5f;       // seconds between each enemy spawn
    public float timeBetweenWaves = 2f;      // cooldown after finishing a wave

    private bool isSpawning = false;
    private int currentWave = 0;

    void Start()
    {
        if (enemy == null) Debug.LogError("waveSpawner: enemy prefab not assigned!");
        if (spawner1 == null && spawner2 == null && spawner3 == null && spawner4 == null && spawner5 == null)
            Debug.LogError("waveSpawner: no spawners assigned!");
    }

    void Update()
    {
        // If no enemies remain and we're not already spawning, start the next wave
        if (!isSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
           StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        isSpawning = true;
        currentWave++;

        GameObject[] spawners = new GameObject[] { spawner1, spawner2, spawner3, spawner4, spawner5 };

        for (int i = 0; i < enemiesPerWave; i++)
        {
            // choose a random non-null spawner
            GameObject spawnPoint = null;
            do
            {
                spawnPoint = spawners[Random.Range(0, spawners.Length)];
            } while (spawnPoint == null);

            Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }

        // optional cooldown before allowing the next wave
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = false;
    }
}
