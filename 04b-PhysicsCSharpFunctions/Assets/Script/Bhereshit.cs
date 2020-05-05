using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bhereshit : MonoBehaviour {
    [SerializeField] float distanceToStartSlowdown = 0;
    [SerializeField] float dragForceForSlowdown = 0;
    [SerializeField] GameObject explosionEffect;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    /* If the spaceship hits the moon too fast - it explodes: */

    private void OnCollisionEnter2D(Collision2D collision) {
        print("The colllision magnitude is" + rb.velocity.magnitude);
        if (rb.velocity.magnitude > 1) {
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion() {
        explosionEffect.SetActive(true);
        yield return new WaitForSeconds(0.68f);
        Destroy(this.gameObject);
    }


    /* To prevent explosion - send a ray to the moon and "drag" the spaceship when the moon is nearby: */

    private void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
        if (hit.collider != null && hit.distance <= distanceToStartSlowdown) {  // If there is an object sufficiently close to the spaceship -
            rb.drag = dragForceForSlowdown;      // Add drag, to slow down the spaceship.
        }

        // To see the Gizmo of the ray in the Scene:
        Debug.DrawRay(transform.position, Vector2.down * distanceToStartSlowdown, Color.red);
    }
}
