using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointPlaneController : MonoBehaviour
{
    public void InitPointsPlane(float planePoints,Vector3 position)
    {
        transform.position = position;
        transform.GetChild(0).GetComponent<PointCubeTransparanController>().InitTransparanController(planePoints);
    }
}
