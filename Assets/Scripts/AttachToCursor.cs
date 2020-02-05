using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToCursor : MonoBehaviour
{
    new private Camera camera;
    private MouseOrbitalMotion orbitalMotion;

    private void Awake() {
        camera = Camera.main;
        orbitalMotion = camera.GetComponent<MouseOrbitalMotion>();
    }

    private void Update() {
        transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, orbitalMotion.GetDistanceFromTarget() * 0.9f));
    }
}
