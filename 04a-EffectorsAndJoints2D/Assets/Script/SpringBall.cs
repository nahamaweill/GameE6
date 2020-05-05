using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBall : MonoBehaviour {
    private bool isPressed = false;
    private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D hook; 
    public float maxDragDistance = 2f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (isPressed) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }
    }

    private void OnMouseDown() {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp() {
        isPressed = false;
        rb.isKinematic = false;
    }

    void OnGUI() {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 16;
        fontSize.normal.textColor = Color.black;
        GUI.Label(new Rect(50, 0, 200, 50), "Distance Joint ", fontSize);
        GUI.Label(new Rect(270, 0, 200, 50), "Spring Joint ", fontSize);
    }
}
