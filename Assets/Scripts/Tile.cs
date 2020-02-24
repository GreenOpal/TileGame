using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ITile, IDraggable
{
    private void Awake()
    {
        Setup();
    }
    public void Setup()
    {
    }


    public void OnPickUp()
    { 
        //Disconnect VFX, SFX, etc
    }

    public void OnPutDown()
    {
        //Find closest grid point for placement
        //Test for tile placement rules
    }
}
