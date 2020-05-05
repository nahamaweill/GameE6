using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour {
    private void Start() {
        Debug.Log("Start");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(this.name + " Trigger with " + other.name);
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(this.name + " Collision with " + collision.collider.name);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(this.name + " Trigger 2D with " + other.name);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(this.name + " Collision 2D with " + collision.collider.name);
    }
}
