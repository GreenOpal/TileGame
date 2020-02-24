using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventController
{

    //Touch controls
    public static Action<Touch> OnMouseDown;
    public static Action<Touch> OnMouseDrag;
    public static Action<Touch> OnMouseUp;

    public static Action<Tile> OnTilePicked;
    public static Action<Tile> OnTileDropped;
}
