using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class waveSpawner : MonoBehaviour
{
    public GameObject spawner1; // bestämer deras spawn punkter
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner5;
   
  [SerializeField] TMP_Text waveCounter;  // räknar vilken wave du är på och konverterar det intill en text
    // Enemy prefab (must have tag "Enemy")
    public GameObject enemy; 

    // Wave settings
    [SerializeField] public int enemiesPerWave = 5;
    public float spawnInterval = 1.6f;       // seconds between each enemy spawn
    public float timeBetweenWaves = 2f;      // cooldown after finishing a wave

    private bool isSpawning = false;  
    private int currentWave = 0;

    void Start() // när vi skapar objektet så kollar vi om vi har tilldelat fiende prefabben och spawners
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
            waveCounter.text = "Wave: " + currentWave.ToString();
        }
        if (currentWave == 10) // om wave är 10 så vinner du
        {
            Debug.Log("You Win!");
          SceneManager.LoadScene("winScene");
        }
        if (currentWave >= 3) // om wave är 3 eller högre så ändras fiendernas antal och spawn tider
        {
            enemiesPerWave = 7;
            timeBetweenWaves = 5f;
            spawnInterval = 2.9f;
        }
        if (currentWave >= 5) // om wave är 5 eller högre så ändras fiendernas antal och spawn tider
        {
            enemiesPerWave = 10;
            timeBetweenWaves = 4.8f;
            spawnInterval = 2.9f;
        }
        if (currentWave >= 8) // om wave är 8 eller högre så ändras fiendernas antal och spawn tider
        {
            enemiesPerWave = 12;
            timeBetweenWaves = 4.7f;
            spawnInterval = 2.9f;
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
            GameObject spawnPoint = null; // om en spawner är null så väljer vi en annan
            do
            {
                spawnPoint = spawners[Random.Range(0, spawners.Length)];
            } while (spawnPoint == null);

            Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity); // spawnar fienden på den valda spawnern
            yield return new WaitForSeconds(spawnInterval);
        }

        // cooldown before allowing the next wave
        yield return new WaitForSeconds(timeBetweenWaves); // vänta tills det blir en ny wave
        isSpawning = false;
    }
}
