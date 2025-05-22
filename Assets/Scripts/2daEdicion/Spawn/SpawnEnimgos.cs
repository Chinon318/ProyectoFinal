using UnityEngine;

public class SpawnEnimgos : MonoBehaviour
{
    public GameObject enemyPrefab;          
    public Transform[] spawnPoints;          
    public float spawnInterval = 5f;         

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return;

        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
