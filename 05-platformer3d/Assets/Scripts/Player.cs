using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {
    CharacterController characterController;

    [Tooltip("In meters per second")] [SerializeField] float speed = 6.0f;
    [Tooltip("In meters per second^2")] [SerializeField] float gravity = 1.0f;
    [SerializeField] int scorePerCoin = 1;
    [SerializeField] TextMeshPro scoreText;

    [Tooltip("In meters per second")] [SerializeField] float jumpSpeed = 8.0f;
    [Tooltip("In meters per second")] [SerializeField] Vector3 velocity;

    int score = 0;

    void Start() {
        characterController = GetComponent<CharacterController>();
        velocity = new Vector3(0, 0, 0);    // in meters per second
        scoreText = transform.Find("Score").GetComponent<TextMeshPro>();
        SetScore(0);
    }

    private void SetScore(int s) {
        score = s;
        scoreText.text = score.ToString();
    }

    public void CollectCoin() {
        SetScore(score + scorePerCoin);
    }

    void Update() {
        if (!characterController.enabled) return;
        velocity.x = Input.GetAxis("Horizontal") * speed;  // +1 m/s  for right, -1 m/s  for left
        if (characterController.isGrounded) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                velocity.y = jumpSpeed;              
            }
        } else {
            float deltaVelocityY = gravity * Time.deltaTime; // in (meters per second) per frame
            velocity.y -= deltaVelocityY;
        }
        characterController.Move(velocity * Time.deltaTime); // in meters per frame
    }
}