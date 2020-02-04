using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionSquare : MonoBehaviour, IPointerClickHandler
{
    public GameObject myPlacementObject;
    UIManager uiHandler;
    private void Awake()
    {
        uiHandler = FindObjectOfType<UIManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        uiHandler.placementObjectPrefab = myPlacementObject;
    }
    
}
