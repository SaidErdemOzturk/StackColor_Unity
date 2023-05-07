using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointsCube : MonoBehaviour
{
    [SerializeField] private GameObject pointsCubePrefab;
    [SerializeField] private GameObject extraCube;
    private GameObject tempObj;
    private CanvasManager canvasManager;
    private PlayerManager playerManager;
    private AnimationManager animationManager;

    private void Start()
    {
        canvasManager = CanvasManager.GetInstance();
        playerManager = PlayerManager.GetInstance();
        animationManager = AnimationManager.GetInstance();
        CreatePointsCubes();
    }

    private void OnTriggerExit(Collider other)
    {
        IStack stack = other.GetComponent<IStack>();
        if(stack != null)
        {
            canvasManager.SpeedSliderActive();
            stack.OnPointsCube();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animationManager.KickAnim();
    }

    public void CreatePointsCubes()
    {
        for (float i = 0; i < PlayerPrefs.GetFloat(Utils.SCORE_ANIM, 5); i += 0.2F)
        {
            tempObj = Instantiate(pointsCubePrefab);
            tempObj.GetComponent<PointPlaneController>().InitPointsPlane((i + 1), new Vector3(0, 0, transform.position.z + (i * 2.5F * 10)));
            tempObj.transform.SetParent(transform);
        }
        extraCube.transform.localPosition = new Vector3(0, 0, PlayerPrefs.GetFloat(Utils.SCORE_ANIM, 5) * 2.5F * 10);
    }
}