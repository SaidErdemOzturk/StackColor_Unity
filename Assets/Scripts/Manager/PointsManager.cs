using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : Singleton<PointsManager>
{
    private int pointCount;
    private CanvasManager canvasManager;
     
    private void Start()
    {
        canvasManager = CanvasManager.GetInstance();
    }


    public void AddPoint(int pointCount)
    {
        this.pointCount += pointCount;
        canvasManager.UpdatePoint(this.pointCount);
    }

    public void RemovePoint(int pointCount)
    {
        this.pointCount -= pointCount;
        canvasManager.UpdatePoint(this.pointCount);

    }

    public int GetPoints()
    {
        return pointCount;
    }
}
