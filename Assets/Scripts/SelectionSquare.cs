using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionSquare : MonoBehaviour, IPointerClickHandler
{
    public GameObject my_placement_object;
    public GameObject ui_handler;

    public void Start()
    {
        ui_handler = GameObject.Find("UI_Manager");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ui_handler.GetComponent<UIManager>().placement_object_prefab = my_placement_object;
    }
    
}
