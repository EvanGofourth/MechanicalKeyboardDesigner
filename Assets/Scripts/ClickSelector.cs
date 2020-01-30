using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectionHandler {
    void OnSelection(GameObject g);
}

[RequireComponent(typeof(Collider), typeof(ISelectionHandler))]
public class ClickSelector : MonoBehaviour
{
    ISelectionHandler[] selectionHandlers;

    private void Awake() {
        selectionHandlers = GetComponents<ISelectionHandler>();
    }
    
    private void OnMouseDown() {
        if (selectionHandlers != null) {
            foreach (var handler in selectionHandlers) {
                handler.OnSelection(gameObject);
            }
        }
    }
}
