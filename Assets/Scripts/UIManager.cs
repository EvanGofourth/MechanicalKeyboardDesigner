using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject placement_object_prefab;

    Ray mouse_ray;
    RaycastHit hit;

    GameObject tile;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public GameObject focused_placeholder;

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
        mouse_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouse_ray, out hit))
        {
            if (hit.collider.gameObject.tag == "placeholder")
            {
                focused_placeholder = hit.collider.gameObject;
            }
        }
        else
        {
            focused_placeholder = null;
        }
    }

    void ClickManager()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(focused_placeholder && placement_object_prefab)
            {
                // place the object prefab in the placeholder.
                if(focused_placeholder.GetComponent<Placeholder>().type == placement_object_prefab.GetComponent<Placeable>().type)
                {
                    GameObject temp = Instantiate(placement_object_prefab);
                    temp.transform.position = new Vector3(focused_placeholder.transform.position.x, focused_placeholder.transform.position.y, focused_placeholder.transform.position.z);
                }
                
            }
        }
    }
}
