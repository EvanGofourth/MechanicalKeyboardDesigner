using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject placementObjectPrefab;

    Ray mouseRay;
    RaycastHit hit;

    GameObject tile;

    GraphicRaycaster Raycaster;
    PointerEventData PointerEventData;
    EventSystem EventSystem;

    public GameObject focusedPlaceholder;

    private void Start()
    {
    }

    private void Update()
    {
        ManageMouseHighlighter();
        ClickManager();
    }

    void ManageMouseHighlighter()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out hit))
        {
            if (hit.collider.gameObject.tag == "placeholder")
            {
                focusedPlaceholder = hit.collider.gameObject;
            }
        }
        else
        {
            focusedPlaceholder = null;
        }
    }

    void ClickManager()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(focusedPlaceholder && placementObjectPrefab)
            {
                // place the object prefab in the placeholder.
                if(focusedPlaceholder.GetComponent<Placeholder>().type == placementObjectPrefab.GetComponent<Placeable>().type && focusedPlaceholder.GetComponent<Placeholder>().occupied == false)
                {
                    GameObject temp = Instantiate(placementObjectPrefab);
                    temp.transform.position = new Vector3(focusedPlaceholder.transform.position.x, focusedPlaceholder.transform.position.y, focusedPlaceholder.transform.position.z);
                    focusedPlaceholder.GetComponent<Placeholder>().occupied = true;
                }
                
            }
        }
    }
}
