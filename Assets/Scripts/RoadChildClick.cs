using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadChildClick : MonoBehaviour
{
    private bool mouseOver;

    void Start()
    {
        mouseOver = false;
    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

    void Update()
    {
        if (mouseOver && Input.GetMouseButtonDown(0))
            GetComponentInParent<RoadController>().UnlockRoad();
    }
}
