using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PointCubeTransparanController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI pointsText;
    [SerializeField] private ParticleSystem particle;
    private float points;
    private GameManager gameManager;
    private CameraController cameraController;
    private ParticleSystem tempParticle;
    private void Start()
    {
        gameManager = GameManager.GetInstance();
        cameraController = CameraController.GetInstance();
    }

    public void InitTransparanController(float points)
    {
        this.points = points;
        pointsText.text = points.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (cameraController.GetCameraPosition().z < transform.position.z)
        {
            tempParticle= Instantiate(particle);
            tempParticle.transform.position = transform.parent.transform.position;
            cameraController.CameraMoveToPointsPlane(transform.position);
            GetComponent<BoxCollider>().isTrigger = false;
            gameManager.OnPointsCube(points);
            Destroy(gameObject);
        }
    }
}
