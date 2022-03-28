using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Stuff")]

    public Transform enemyPrefab;
    public Transform enemySpawnLocation;
    public Transform spawnPoint;

    [Header("Canvas Stuff")]
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 0;
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, enemySpawnLocation.transform);

    }
}