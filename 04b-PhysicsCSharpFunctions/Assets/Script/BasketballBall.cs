﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketballBall: MonoBehaviour {
    [SerializeField] float forceToAdd = 1300f;
    [SerializeField] float timeFromHittingTheFloorToRestart = 2f;

    private Rigidbody2D rb;
    private Vector3 endPosition;
    private Vector3 startPosition;
    private int Score = 0;
    private SpringJoint2D sj;

    private void Start()  {
        sj = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown() {
        sj.enabled = false;
        rb.isKinematic = true;
        startPosition = GetMouseAsWorldPoint();
    }

    void OnMouseDrag() {
        transform.position = GetMouseAsWorldPoint();
    }

    void OnMouseUp() {
        rb.isKinematic = false;
        endPosition = GetMouseAsWorldPoint();
        Vector3 forceVector = (endPosition - startPosition).normalized;
        rb.AddForce(forceVector * forceToAdd);
    }

    private Vector3 GetMouseAsWorldPoint() {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePoint.z = transform.position.z;
        return mousePoint;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "boundery") {
            RestartLevel();
        } else if (other.tag == "Platform") {
            StartCoroutine(HitTheFloor());
            print("Platform");
        }
    }

    IEnumerator HitTheFloor() {
        yield return new WaitForSeconds(timeFromHittingTheFloorToRestart);
        RestartLevel();
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
