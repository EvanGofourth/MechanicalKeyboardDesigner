using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionSquare : MonoBehaviour, IPointerClickHandler
{
    public GameObject placementPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject cursorPlacementObject = GameObject.Instantiate(placementPrefab);
        cursorPlacementObject.AddComponent<AttachToCursor>();
    }
    
}
