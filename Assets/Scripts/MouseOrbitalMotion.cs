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

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        mouseWheelInput = Input.GetAxis("Mouse ScrollWheel");
        mouseVerticalInput = Input.GetAxis("Mouse Y");
        mouseHorizontalInput = Input.GetAxis("Mouse X");

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void LateUpdate() {
        if (Cursor.lockState != CursorLockMode.Locked) {
            return;
        }

        transform.RotateAround(target.position, transform.right, mouseVerticalInput * mouseVerticalSensitivity);
        transform.RotateAround(target.position, target.up, mouseHorizontalInput * mouseHorizontalSensitivity);
        transform.LookAt(target, target.up);

        if (Vector3.Distance(transform.position, target.position) > minimumZoom) {
            transform.Translate(transform.forward * -mouseWheelInput * mouseWheelSensitivity, Space.Self);
        }
    }
}
