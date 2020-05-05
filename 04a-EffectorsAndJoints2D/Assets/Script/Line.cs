using UnityEngine;
using System.Collections;

/**
 * This component draws a line between two gameObjects. 
 * The line moves when the gameObjects move.
 */ 
public class Line : MonoBehaviour {
    [Tooltip("The 1st endpoint of the line")] [SerializeField] GameObject gameObject1;
    [Tooltip("The 2nd endpoint of the line")] [SerializeField] GameObject gameObject2; 

    private LineRenderer line;
    void Start() {
        // Initialize the Line Renderer:
        line = this.gameObject.AddComponent<LineRenderer>();

        // Set the width of the Line Renderer:
        line.SetWidth(0.05F, 0.05F);

        // Set the number of vertex of the Line Renderer:
        line.SetVertexCount(2);
    }

    void Update() {
        if (gameObject1 != null && gameObject2 != null) {
            // Update position of the two vertices of the Line Renderer:
            line.SetPosition(0, gameObject1.transform.position);
            line.SetPosition(1, gameObject2.transform.position);
        }
    }
}
