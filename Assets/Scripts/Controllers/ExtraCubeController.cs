using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCubeController : MonoBehaviour
{
    [SerializeField] private int extraPoint;
    private CameraController cameraController;
    private PointsManager pointsManager;

    private void Start()
    {
        cameraController = CameraController.GetInstance();
        pointsManager = PointsManager.GetInstance();
    }

    private void OnTriggerEnter(Collider other)
    {
        ICube cube = other.GetComponent<ICube>();
        if(cube != null)
        {
            cameraController.CameraMoveToExtraCube(transform.position);
            pointsManager.AddPoint(extraPoint);
        }
    }
}
