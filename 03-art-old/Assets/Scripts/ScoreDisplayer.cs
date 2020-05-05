using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour {
    ScoreKeeper scoreKeeper = null;
    Text scoreText = null;

    private void Start() {
        scoreKeeper = Object.FindObjectOfType<ScoreKeeper>();
        scoreText = GetComponent<Text>();
    }

    private void Update() {
        if (scoreText && scoreKeeper) {
            scoreText.text = scoreKeeper.Score().ToString();
        }
    }
}
