using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeScore : MonoBehaviour
{
    private TextMeshPro textField = new TextMeshPro();
    private static int number = 3;

    void Start()
    {
        textField = GetComponent<TextMeshPro>();
        if (!textField)
            throw new MissingComponentException("Object must contain a TextMeshPro field!");
    }

    public int GetNumber()
    {
        return LifeScore.number;
    }

    public void SetNumber(int newNumber)
    {
        LifeScore.number = newNumber;
        textField.text = LifeScore.number.ToString();
    }

    void Update()
    {
        if (LifeScore.number != -1)
            textField.text = LifeScore.number.ToString();
    }
}



