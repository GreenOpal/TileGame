using UnityEngine;

public static class Layers
{
    public static LayerMask GetMask(int layerNum)
    {
        return LayerMask.GetMask(LayerMask.LayerToName(layerNum));
    }
    public static int Tile = 8;
}
