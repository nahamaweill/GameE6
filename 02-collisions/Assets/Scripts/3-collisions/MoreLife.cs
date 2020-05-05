using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreLife : MonoBehaviour
{
    [SerializeField] LifeScore scoreField;

    // Start is called before the first frame update
    void Start()
    {
        scoreField = new LifeScore();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player get 1 Life");
            scoreField.SetNumber(scoreField.GetNumber() + 1);
            Destroy(gameObject);  // Destroy the shield itself - prevent double-use
       
        }
        else
        {
            Debug.Log("Life triggered by " + other.name);
        }
    }
}
