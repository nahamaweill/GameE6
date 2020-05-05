using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    [Tooltip("How many seconds the object remains in attack mode")][SerializeField] float duration = 1f;
    Animator animator;
    Mover mover;

    void Start() {
        animator = GetComponent<Animator>();
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            StartCoroutine(GoToAttackMode());
        }
    }

    IEnumerator GoToAttackMode() {
        mover.enabled = false;
        animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(duration);
        animator.SetBool("IsAttacking", false);
        mover.enabled = true;
    }
}
