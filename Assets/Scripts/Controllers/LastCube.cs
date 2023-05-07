using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LastCube : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSpeed;
    private float tempSpeed;
    private CanvasManager canvasManager;
    private PlayerManager playerManager;
    private GameManager gameManager;
    private ParticleSystem.EmissionModule tempEmission;
    private ParticleSystem tempParticle;

    private void Start()
    {
        canvasManager = Singleton<CanvasManager>.GetInstance();
        playerManager = Singleton<PlayerManager>.GetInstance();
        gameManager = Singleton<GameManager>.GetInstance();

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        IStack stack = other.GetComponent<IStack>();
        if (stack != null)
        {
            tempSpeed = 2;
            playerManager.SetSpeed(tempSpeed);
            tempParticle=Instantiate(particleSpeed);
            tempParticle.transform.position = transform.position+new Vector3(0,2,20);
            stack.OnLastCube();
        }
    }
    private void Update()
    {
        if (gameManager.GetPlayType() == PlayType.Last)
        {
            tempSpeed = playerManager.GetSpeed();
            tempSpeed -= Time.deltaTime * 5;
            playerManager.SetSpeed(tempSpeed);
            canvasManager.UpdateSlider(tempSpeed);
            tempEmission = tempParticle.emission;
            tempEmission.rateOverTime = tempSpeed*2;
            if (playerManager.GetSpeed() < 2)
            {
                tempSpeed = 2;
                playerManager.SetSpeed(tempSpeed);
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (playerManager.GetSpeed() < 10)
                {
                    tempSpeed += 2;
                    playerManager.SetSpeed(tempSpeed);
                }
                else
                {
                    tempSpeed = 10;
                    playerManager.SetSpeed(tempSpeed);

                }
            }

        }
    }
}
