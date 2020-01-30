using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MouseOrbitalMotion : MonoBehaviour
{
    public Transform target;
    public float minimumZoom = 0.2f;
    public float mouseWheelSensitivity = 1f;
    public float mouseVerticalSensitivity = 1f;
    public float mouseHorizontalSensitivity = 1f;

    float mouseWheelInput = 0f;
    float mouseVerticalInput = 0f;
    float mouseHorizontalInput = 0f;

    private void Update() {
        mouseWheelInput = Input.GetAxis("Mouse ScrollWheel");
        mouseVerticalInput = Input.GetAxis("Mouse Y");
        mouseHorizontalInput = Input.GetAxis("Mouse X");
    }

    private void LateUpdate() {
        if (Input.GetMouseButton(1)) {
            transform.RotateAround(target.position, transform.right, mouseVerticalInput * mouseVerticalSensitivity);
            transform.RotateAround(target.position, target.up, mouseHorizontalInput * mouseHorizontalSensitivity);
        }
        if (Vector3.Distance(transform.position, target.position) > minimumZoom) {
            transform.LookAt(target, transform.up);
            transform.Translate(transform.forward * mouseWheelInput * mouseWheelSensitivity, Space.World);
        } else {
            transform.LookAt(target, transform.up);
            transform.Translate(-transform.forward, Space.World);
        }
    }
}
