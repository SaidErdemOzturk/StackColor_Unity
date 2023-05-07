using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private float changeValue;
    [SerializeField] private Vector3 onPointsPlanePosition;
    [SerializeField] private Vector3 onPointsPlaneRotation;
    [SerializeField] private Vector3 onLastCubePosition;
    [SerializeField] private Vector3 onLastCubeRotation;
    [SerializeField] private Vector3 onExtraCubePosition;
    [SerializeField] private Vector3 onExtraCubeRotation;
    private GameManager gameManager;
    private PlayerManager playerManager;
    private Vector3 tempPosition;
    private Vector3 tempRotation;
    private Vector3 offset;

    private void Start()
    {
        gameManager = GameManager.GetInstance();
        playerManager = PlayerManager.GetInstance();
        offset = transform.position - playerManager.transform.position;
    }

    private void FixedUpdate()
    {
        if (gameManager.GetPlayType()!=PlayType.Finish)
        {
            transform.position = Vector3.Lerp(transform.position, playerManager.transform.position + offset, 0.5F);
        }
    }

    public void CameraMoveToLastCubePosition()
    {
        transform.DOMove(playerManager.transform.position+onLastCubePosition,0.5F);
        transform.DORotate(onLastCubeRotation, 1, RotateMode.Fast);
    }

    public void CameraMoveToPointsPlane(Vector3 planePosition)
    {
        tempPosition = planePosition;
        transform.DOMove(tempPosition+ onPointsPlanePosition, 1F).SetEase(Ease.OutSine);
        CameraRotate(onPointsPlaneRotation);
        CameraRotate(new Vector3(10, -15, 0));
    }

    public void CameraMoveToExtraCube(Vector3 extraCubePosition)
    {
        tempPosition = extraCubePosition;
        transform.DOMove(tempPosition+onExtraCubePosition,1F).SetEase(Ease.OutQuint);
        CameraRotate(onExtraCubeRotation);
    }
    public void OnCubeIncreasePosition()
    {
        offset += new Vector3(0, 0.02F, 0);
        CameraIncreaseRotationX();
    }

    public void OnCubeDecreeasePosition()
    {
        offset -= new Vector3(0, 0.02F, 0);
        CameraIncreaseRotationX();
    }

    public void CameraIncreaseRotationX()
    {
        tempRotation = transform.eulerAngles;
        tempRotation += new Vector3(changeValue,0,0);
        CameraRotate(tempRotation);
    }

    public void CameraDecreaseRotationX()
    {
        tempRotation = transform.eulerAngles;
        tempRotation -= new Vector3(changeValue, 0, 0);
        CameraRotate(tempRotation);
    }

    private void CameraRotate(Vector3 rotate)
    {
        transform.DORotate(rotate,0.5F);
    }

    public Vector3 GetCameraPosition()
    {
        return tempPosition;
    }
}
