using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A base class for all power-ups in this game.
 */
public abstract class Powerup : MonoBehaviour
{
    [Tooltip("How many seconds this powerup remains active")] [SerializeField] protected float duration = 1f;

    public abstract void activate(PlayerController player);

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerController>()) {
            activate(other.GetComponent<PlayerController>());
            Destroy(this.gameObject);  // a powerup can be used only once
        }
    }
}
