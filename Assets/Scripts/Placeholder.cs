using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Placeholder : MonoBehaviour
{

    public Material visible;
    public Material transparent;

    public bool occupied;
    public float type; //expressed as 1f for a 1u keycap, 1.25f for a 1.25u keycap, etc.. spacebar is always 6f.

    private void Awake()
    {
        occupied = false;
    }

    private void Update()
    {
        if(occupied)
        {
            this.gameObject.GetComponent<Renderer>().material = transparent;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = visible;
        }
    }
}
