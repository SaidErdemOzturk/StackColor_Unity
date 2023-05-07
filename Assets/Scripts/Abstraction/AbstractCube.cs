using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractColor : MonoBehaviour
{
    public ColorType colorType;
    public Material material;

    public void ChangeColor(ColorType colorType)
    {
        switch (colorType)
        {
            case ColorType.red:
                this.colorType = ColorType.red;
                material.color = Color.red;
                break;
            case ColorType.green:
                this.colorType = ColorType.green;
                material.color = Color.green;
                break;
            case ColorType.blue:
                this.colorType = ColorType.blue;
                material.color = Color.blue;
                break;
            default:
                break;
        }
    }
    public Color GetColor()
    {
        return material.color;
    }
}
