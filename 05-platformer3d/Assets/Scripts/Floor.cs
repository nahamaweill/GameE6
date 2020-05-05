using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    [SerializeField] Transform respawnPoint;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Player>()) {
            var controller = other.GetComponent<CharacterController>();
            if (controller) {
                controller.enabled = false;
            }
            other.transform.position = respawnPoint.position;
            StartCoroutine(EnableController(controller));
        }
    }

    private IEnumerator EnableController(CharacterController controller) {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
