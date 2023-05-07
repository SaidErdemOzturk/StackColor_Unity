using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : AbstractColor
{


    private void Start()
    {
        material = GetComponent<Renderer>().material;
        ChangeColor(colorType);
    }
}
