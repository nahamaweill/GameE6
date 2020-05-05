using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour {
    [SerializeField] GameObject prefabToSpawn;
    [Tooltip("Time between consecutive spawns, in seconds")] [SerializeField] float timeBetweenSpawns = 1f;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine() {
        while (true) {
            Vector3 postospawn = transform.position;
            GameObject new_enemy = Instantiate(prefabToSpawn, postospawn, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
