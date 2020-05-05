using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Represents an object that has a given amount of lives, and is destroyed when the number of lives becomes 0.
 */
public class HealthSystem : MonoBehaviour
{
    [Tooltip("Num of hits before the object is dead")] [SerializeField] int lives = 3;
    [Tooltip("Num of seconds to wait before destroying the object")] [SerializeField] float deathDelay = 1f;
    [Tooltip("Display of the remaining lives")] [SerializeField] LivesKeeper livesKeeper = null;
    [Tooltip("Index of the scene that displays 'game over'")] [SerializeField] int gameOverSceneIndex = -1;

    Transform explosion;

    private void Start() {
        explosion = transform.Find("ExplosionEffect");

        if (livesKeeper) {
            livesKeeper.SetLives(lives);
        }
    }

    public void Damage() {
        --lives;

        // Notify the player that a damage was done:
        gameObject.transform.localScale *= 0.75f;
        if (livesKeeper) {
            livesKeeper.SetLives(lives);
        }

        if (lives<1) {
            Explosion();
            StartCoroutine(GameOver());
        }
    }

    void Explosion() {
        if (explosion) {
            explosion.gameObject.SetActive(true);
            gameObject.GetComponent<Renderer>().enabled = false; // hide player during the xplosion
        }
        //Destroy(gameObject, deathDelay); // This will be done by an animation event.
    }

    IEnumerator GameOver() {
        yield return new WaitForSeconds(deathDelay);
        if (gameOverSceneIndex >= 0) {
            SceneManager.LoadScene(gameOverSceneIndex);
        }
    }
}
