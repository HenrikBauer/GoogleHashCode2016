using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct IntVector2
{
    public int x;
    public int y;

    public IntVector2(int newX, int newY)
    {
        x = newX;
        y = newY;
    }

    public float Distance(IntVector2 v)
    {
        float r1 = x - v.x;
        float r2 = y - v.y;

        return (float)Math.Sqrt(r1 * r1 + r2 * r2);
    }
}

