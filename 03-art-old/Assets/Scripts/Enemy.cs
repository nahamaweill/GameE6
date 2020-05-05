using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Tooltip("Direction and speed of movement, in units/sec")]
    [SerializeField] Vector3 speedVector;

    ScoreKeeper scoreKeeper = null;
    bool isDying = false;

    // Start is called before the first frame update
    void Start() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    // Update is called once per frame
    void Update() {
        transform.Translate(speedVector * Time.deltaTime);
        // TODO: destroy when out of screen
    }

    // Detect the collider type by its component:
    private void OnTriggerEnter2D(Collider2D collision) {
        var other = collision.gameObject;
        if (other.GetComponent<Laser>()) {
            Debug.Log("Enemy is hit by laser!");
            if (scoreKeeper)
                scoreKeeper.IncrementScore();
            this.GetComponent<HealthSystem>().Damage();
            Destroy(other.gameObject);
        } else if (other.GetComponent<PlayerController>() && !isDying) {
            Debug.Log("Enemy hits the player!");
            other.GetComponent<PlayerController>().HitEnemy();
            this.GetComponent<HealthSystem>().Damage();
            isDying = true;
        } else {
           // Debug.Log("Enemy crashes into something unidentified: "+other);
        }
    }

    /*
    // Detect the collider type by its tag:
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Laser") {
            Debug.Log("Enemy is hit by laser!");
            Destroy(this.gameObject);
        } else if (other.tag=="Player") {
            Debug.Log("Enemy hits the player!");
            Destroy(other.gameObject);
        } else if (other.tag=="Wall") {
            Debug.Log("Enemy crashes into wall!");
            Destroy(this.gameObject);
        }
    }
    */


}
