using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker 
{
    public static float[] GetColor(int id)
    {
        switch (id)
        {
            case 0:
                return new[] { Color.red.r, Color.red.g, Color.red.b};
            case 1:
                return new[] { Color.yellow.r, Color.yellow.g, Color.yellow.b};
            case 2:
                return new[] { Color.green.r, Color.green.g, Color.green.b};
            case 3:
                return new[] { Color.magenta.r, Color.magenta.g, Color.magenta.b};
        }
        
        return new[] { Color.red.r, Color.red.g, Color.red.b}; 
    }
    
}
