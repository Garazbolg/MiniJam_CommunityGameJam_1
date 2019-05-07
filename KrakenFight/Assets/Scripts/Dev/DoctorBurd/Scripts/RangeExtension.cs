using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RangeExtension
{
    public static bool Between(this int value,int min,int max)
    {
        return value >= min && value <= max;
    }
}
