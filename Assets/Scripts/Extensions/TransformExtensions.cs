using UnityEngine;

public static class TransformExtensions {
    public static void SetX(this Transform t, float value)
    {
        t.transform.position = new Vector3(value, t.transform.position.y, t.transform.position.z);
    }
}

