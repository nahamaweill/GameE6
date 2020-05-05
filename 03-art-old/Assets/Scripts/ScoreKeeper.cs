using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    [SerializeField] int score = 0;

    public void IncrementScore() {
        score++;
    }

    public int Score() {
        return score;
    }
}
