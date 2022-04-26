using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0; 

    public WaveAction[] waves;

    [Header("Enemy Stuff")]
    public Transform enemySpawnLocation;
    public Transform spawnPoint;

    [Header("Canvas Stuff")]
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI roundCounterText;
    public float maxRound = 0;

    public GameManager gameManager;

    private int waveIndex = 0;

    void OnEnable()
    {
        EnemiesAlive = 0;
    }
    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        roundCounterText.text = "Round " + PlayerStats.Rounds + "/" + maxRound.ToString();
    }
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        if (waves.Length > waveIndex)
        {
            WaveAction wave = waves[waveIndex];
            for (int z = 0; z < wave.enemies.Length; z++)
            {
                for (int i = 0; i < wave.enemies[z].count; i++)
                {
                    SpawnEnemy(wave.enemies[z].enemy);
                    yield return new WaitForSeconds(1f / wave.spawnRate);
                }
            }
            waveIndex++;
        }
        else
        {
            this.enabled = false;
         }
    }
    void SpawnEnemy(GameObject enemy)
    {
         Instantiate(enemy, spawnPoint.position, spawnPoint.rotation, enemySpawnLocation.transform);
        EnemiesAlive++;
    }
}
