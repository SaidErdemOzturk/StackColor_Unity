using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour,ICollectable
{
    public void Collect(Action<CoinController> collect)
    {
        collect?.Invoke(this);
    }
}
