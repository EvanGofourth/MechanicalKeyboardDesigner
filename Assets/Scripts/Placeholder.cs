using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Placeholder : MonoBehaviour
{
    public Material visible;
    public Material transparent;
    public bool occupied = false;
    public float type; //expressed as 1f for a 1u keycap, 1.25f for a 1.25u keycap, etc.. spacebar is always 6f.

    new private MeshRenderer renderer;
    new private BoxCollider collider;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material = visible;
        collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
    }

    private void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            KeycapType keycapType = other.GetComponent<KeycapType>();
            if (keycapType !=  null && keycapType.type == type) {
                renderer.material = visible;
                Destroy(keycapType.gameObject);
            }
        }
    }
}
