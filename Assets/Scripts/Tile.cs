using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ITile
{
    private void Awake()
    {
        Setup();
    }
    public void Setup()
    {
        EventController.OnMouseDown += HandleMouse;
    }

    private void HandleMouse(Touch touch)
    {
        Debug.Log("got touch " + touch.position);
    }
}
