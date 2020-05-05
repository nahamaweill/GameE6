using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Denotes a static wall
public class Wall : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
