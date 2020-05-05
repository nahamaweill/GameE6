using UnityEngine;

/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover: MonoBehaviour {
    [Tooltip("Direction and speed of movement, in meters per second")]
    [SerializeField] Vector3 velocity;

    void Update() {
        transform.position += velocity * Time.deltaTime;
    }
}
