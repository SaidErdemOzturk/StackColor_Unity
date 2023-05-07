using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType
{
    red, green, blue,
}

public class CubeController : AbstractColor, ICube,IObstacleable
{
    //colorType, material ve ChangeColor abstractColor içerisinde

    [SerializeField] private float mass;
    public int count;
    private CameraController camera;
    private PointsManager pointsManager;
    private bool isCollected;

    private void Start()
    {
        pointsManager = PointsManager.GetInstance();
        camera = CameraController.GetInstance();
        material = GetComponent<Renderer>().material;
        ChangeColor(colorType);
    }

    public void Remove(float destroyTime)
    {
        Destroy(gameObject,destroyTime);
    }

    public void OnInteract(Action<CubeController> callback)
    {
        if (isCollected)
        {
            return;
        }
        callback?.Invoke(this);
        isCollected = true;
    }

    public float GetMass()
    {
        return mass;
    }

    public void Obstacled(Action<CubeController> callback)
    {
        callback?.Invoke(this);
    }
}
