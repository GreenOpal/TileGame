using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovementController : MonoBehaviour
{

    private Camera mainCamera;
    private LayerMask tileMask;

    private Tile currentTile;

    private Vector3 pickupOffset;

    private void Awake()
    {
        //Cache our data to avoid needing to find it every click down
        mainCamera = Camera.main;
        tileMask = Layers.GetMask(Layers.Tile);

        EventController.OnMouseDown += CheckForTile;
        EventController.OnMouseDrag += DragTile;
        EventController.OnMouseUp += DropTile;
    }





    private void CheckForTile(Touch touch)
    {
        Ray ray = mainCamera.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, tileMask, QueryTriggerInteraction.Collide))
        {
            currentTile = hit.collider.GetComponent<Tile>();
            if (currentTile)
            {
                currentTile.OnPickUp();
                pickupOffset = currentTile.transform.position - mainCamera.ScreenToWorldPoint(touch.position).SetZ(0);
            }

        }
    }

    private void DragTile(Touch touch)
    {
        if (!currentTile)
            return;

        Vector3 tilePos = mainCamera.ScreenToWorldPoint(touch.position).SetZ(0) + pickupOffset;
        currentTile.transform.position = tilePos;
    }

    private void DropTile(Touch touch)
    {
        if (!currentTile)
            return;

        currentTile.OnPutDown();

        currentTile = null;
    }
}
