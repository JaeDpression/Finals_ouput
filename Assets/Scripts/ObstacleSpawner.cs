using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;
    public bool canSpawn = false; // Add this line

    private float nextSpawnTime;

    private void Update()
    {
        if (!canSpawn) return; // Add this line to prevent spawning

        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    private void SpawnObstacle()
    {
        float randomX = Random.Range(-8f, 8f);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
