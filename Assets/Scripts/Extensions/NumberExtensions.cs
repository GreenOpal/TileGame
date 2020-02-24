using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumberExtensions
{
    public static float RoundNum(this float num, float modulo)
    {
        float rem = num % modulo;
        float half = modulo / 2f;
        return rem >= half ? (num - rem + modulo) : (num - rem);
    }
}
