using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovementController : MonoBehaviour
{

    private Camera mainCamera;
    private LayerMask tileMask;

    private Tile currentTile;

    private Vector2 screenScale;

    private void Awake()
    {
        //Cache our data to avoid needing to find it every click down
        mainCamera = Camera.main;
        tileMask = Layers.GetMask(Layers.Tile);
        screenScale = new Vector2(1f / Screen.width, 1f / Screen.height);
        Debug.Log(screenScale);

        EventController.OnMouseDown += CheckForTile;
        EventController.OnMouseDrag += DragTile;
    }

    private void DragTile(Touch touch)
    {
        if (!currentTile)
            return;

        Vector3 tilePos = mainCamera.ScreenToWorldPoint(touch.position).SetZ(0);
        currentTile.transform.position = tilePos;
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
                Debug.Log(currentTile.transform.position);
            }

        }
    }
}
