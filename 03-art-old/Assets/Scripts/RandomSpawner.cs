using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {
    [SerializeField] GameObject[] prefabsToSpawn;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 0.5f;
    static int numSpawnedSoFar = 0;

    void Start() {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine() {
        while (true) {
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 postospawn = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);
            var prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
            GameObject newObject = Instantiate(prefabToSpawn, postospawn, Quaternion.identity);
            newObject.name = prefabToSpawn.name + " #" + numSpawnedSoFar;
            numSpawnedSoFar++;
        }
    }
}
