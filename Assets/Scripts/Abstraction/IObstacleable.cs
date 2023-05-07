using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleable
{
    void Obstacled(Action<CubeController> callback);
}
