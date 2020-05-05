using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] LifeScore scoreField;
    [SerializeField] int pointsToSub;

    void Start()
    {
        scoreField = new LifeScore();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == triggeringTag && enabled)
        {
            if (this.tag == "Player" && other.tag == "Enemy")
            {
                scoreField.SetNumber(scoreField.GetNumber() - pointsToSub);

                if (scoreField.GetNumber() == -1)
                {                    
                    Destroy(this.gameObject);
                }
            }
            else
            {
                Destroy(this.gameObject);
            }

            Destroy(other.gameObject);
        }
    }
}
