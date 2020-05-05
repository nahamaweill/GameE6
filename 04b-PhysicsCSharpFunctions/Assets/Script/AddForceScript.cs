using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceScript : MonoBehaviour {
    Rigidbody rb;
    [SerializeField] float _force = 10f;
    [SerializeField] float _torque = 10f;

    private float LinearVelocity;
    private float AngularVelocity;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        LinearVelocity = rb.velocity.magnitude;
        AngularVelocity = rb.angularVelocity.magnitude;
        rb.AddForce (Vector3.forward * _force, ForceMode.Force);
        rb.AddTorque(Vector3.forward * _torque, ForceMode.Force);
    }

    void OnGUI() {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 22;
        fontSize.normal.textColor = Color.black;
        GUI.Label(new Rect(100, 0, 200, 50),  "LinearSpeed: "  + LinearVelocity.ToString("F2"), fontSize);
        GUI.Label(new Rect(100, 50, 200, 50), "AngularSpeed: " + AngularVelocity.ToString("F2"), fontSize);
    }
}
