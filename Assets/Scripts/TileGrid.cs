using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TileGrid : MonoBehaviour, IGrid
{


    [SerializeField]
    private int width = 5;

    [SerializeField]
    private int height = 5;

    [SerializeField] 
    private Dictionary<Vector2Int, Tile> TileMap;

    [SerializeField] private LineRenderer linePrefab;

    private float tileSize = 1;
    private float boundedWidth;
    private float boundedHeight;

    public void Setup()
    {
        void GenerateGrid()
        {
            boundedWidth = Width() * tileSize / 2f;
            boundedHeight = Height() * tileSize/ 2f;

            //Build a grid of line renderers, centered on the origin
            for (int row = 0; row <= Width(); row++) // We extend past width/height to build the exterior part of it
            {
                LineRenderer nextLine = Instantiate(linePrefab, this.transform);
                nextLine.positionCount = 2;
                float xPos = Mathf.Lerp(-boundedWidth, boundedWidth, Mathf.InverseLerp(0, Width(), row));
                Vector3 startPos = new Vector3(xPos, -boundedHeight, 0);
                Vector3 endPos = new Vector3(xPos, boundedHeight, 0);
                nextLine.SetPositions(new Vector3[] { startPos, endPos });
            }
            for (int column = 0; column <= Height(); column++)
            {
                LineRenderer nextLine = Instantiate(linePrefab, this.transform);
                nextLine.positionCount = 2;
                float yPos = Mathf.Lerp(-boundedHeight, boundedHeight, Mathf.InverseLerp(0, Width(), column));
                Vector3 startPos = new Vector3(-boundedWidth, yPos, 0);
                Vector3 endPos = new Vector3(boundedWidth, yPos, 0);
                nextLine.SetPositions(new Vector3[] { startPos, endPos });
            }

        }

        

        GenerateGrid();
        EventController.OnTileDropped += CheckTileLocation;
    }

    private void CheckTileLocation(Tile tile)
    {
        tile.transform.position = NearestGridPosition(tile.transform.position);
    }

    public Vector2 NearestGridPosition(Vector2 current)
    {
        float maxTileXPos = boundedWidth - tileSize / 2f;
        float maxTileYPos = boundedHeight - tileSize / 2f;
        float xPos = current.x.RoundNum(tileSize);
        xPos = Mathf.Clamp(xPos, -maxTileXPos, maxTileXPos);

        float yPos = current.y.RoundNum(tileSize);
        yPos = Mathf.Clamp(yPos, -maxTileYPos, maxTileYPos);

        return new Vector2(xPos, yPos);
    }

    public int Width() => width;
    public int Height() => height;


    private void Awake()
    {
        Setup();
    }
}
