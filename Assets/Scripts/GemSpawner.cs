using System.Collections;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPrefab;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found!");
            return;
        }
        StartCoroutine(SpawnGems());
    }

    private IEnumerator SpawnGems()
    {
        while (GameManager.Instance.IsGameActive)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            SpawnGem();
        }
    }

    private void SpawnGem()
    {
        if (gemPrefab == null)
        {
            Debug.LogError("Gem Prefab is not assigned!");
            return;
        }

        // Get screen dimensions in world units
        float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float screenHeight = mainCamera.orthographicSize;

        // Generate a random position within screen bounds
        float randomX = Random.Range(-screenWidth, screenWidth);
        float randomY = Random.Range(-screenHeight, screenHeight);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
    }
}
