using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Speed of player movement, in meters per second")] [SerializeField] float speed = 1f;
    [Tooltip("Prefab for laser shot by the player")] [SerializeField] GameObject laserPrefab = null;
    [Tooltip("Prefab for triple-shot")] [SerializeField] GameObject triplePrefab = null;

    bool isTripleShotActive = false;
    bool isShieldActive = false;
    LivesKeeper livesKeeper = null;

    private void Start() {
        livesKeeper = FindObjectOfType<LivesKeeper>();
    }

    public void ActivateTripleShot(float seconds) {
        StartCoroutine(ActivateTripleShotCouroutine(seconds));
    }

    private IEnumerator ActivateTripleShotCouroutine(float seconds) {
        isTripleShotActive = true;
        yield return new WaitForSeconds(seconds);
        isTripleShotActive = false;
    }

    public void ActivateShield(float seconds) {
        StartCoroutine(ActivateShieldCouroutine(seconds));
    }

    private IEnumerator ActivateShieldCouroutine(float seconds) {
        isShieldActive = true;
        var shield = transform.Find("Shield");
        if (shield)
            shield.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        if (shield)
            shield.gameObject.SetActive(false);
        isShieldActive = false;
    }

    public void HitEnemy() {
        if (!isShieldActive) {
            GetComponent<HealthSystem>().Damage();
        }
    }

    // Update is called once per frame
    void Update() {
        MovePlayer();
        Shoot();
    }

    private void Shoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 laserPosition = new Vector3(transform.position.x, transform.position.y + 1, 0);
            Quaternion laserRotation = Quaternion.identity;
            var shotPrefab = isTripleShotActive ? triplePrefab : laserPrefab;
            Instantiate(shotPrefab, laserPosition, laserRotation);
        }
    }
    
    private void MovePlayer() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);
    }

}
