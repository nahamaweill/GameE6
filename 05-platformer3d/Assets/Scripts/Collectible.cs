using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour{
    private void OnTriggerEnter(Collider other) {
        Player player = other.GetComponent<Player>();
        if (player) {
            player.CollectCoin();
            Destroy(gameObject);
        }
    }
}
