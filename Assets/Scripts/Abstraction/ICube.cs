using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICube
{
    void OnInteract(Action<CubeController> callback);
}
