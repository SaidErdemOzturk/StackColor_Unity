using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : AbstractColor,IStack
{
    [SerializeField] private float cubeGap;
    [SerializeField] private PhysicMaterial physicMaterial;
    private CameraController camera;
    private CanvasManager canvasManager;
    private PlayerManager playerManager;
    private GameManager gameManager;
    private PointsManager pointsManager;
    private CoinManager coinManager;
    public List<CubeController> listCube;
    private Vector3 target;
    private CubeController firstTempCube;
    private CubeController secondTempCube;
    private float tempSpeed;
    private Rigidbody cubeRb;
    private void Start()
    {
        canvasManager = CanvasManager.GetInstance();
        camera = CameraController.GetInstance();
        playerManager = PlayerManager.GetInstance();
        gameManager = GameManager.GetInstance();
        pointsManager = PointsManager.GetInstance();
        coinManager = CoinManager.GetInstance();
        listCube = new List<CubeController>();
        material = GetComponent<Renderer>().material;
        ChangeColor(colorType);
    }

    private void OnEnable()
    {
        ActionsManager.PositionChange += PositionChange;
    }

    private void OnDisable()
    {
        ActionsManager.PositionChange -= PositionChange;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ICollectable>()?.Collect(Collect);
        other.GetComponent<ICube>()?.OnInteract(AddCube);
    }

    private void Collect(CoinController coin)
    {
        coinManager.AddCoin(1);
        Destroy(coin.gameObject);
    }

    private void AddCube(CubeController cube)
    {
        if (cube.colorType == colorType)
        {
            Debug.Log(cube.name);
            listCube.Add(cube);
            cube.count = listCube.Count-1;
            camera.OnCubeIncreasePosition();
            cube.gameObject.GetComponent<Collider>().material = physicMaterial;
            cube.transform.DOScale(cube.transform.localScale + new Vector3(0.5F, 0, 0.5F), 0.1F).SetLoops(2,LoopType.Yoyo);
            cubeRb = cube.gameObject.AddComponent<Rigidbody>();
            cubeRb.isKinematic = true;
            cubeRb.mass = cube.GetMass();
            cubeRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            pointsManager.AddPoint(1);
        }
        else
        {
            if (listCube.Count != 0)
            {
                //0--- destroyTime
                listCube[listCube.Count - 1].GetComponent<BoxCollider>().enabled = false;
                listCube[listCube.Count - 1].Remove(0);
                listCube.Remove(listCube[listCube.Count - 1]);
                pointsManager.RemovePoint(1);
                camera.OnCubeDecreeasePosition();
            }
            else
            {
                gameManager.TryAgain();
            }
        }
    }

    private void PositionChange()
    {

        for (int i = listCube.Count-1; i > 0; i--)
        {

            firstTempCube = listCube[i];
            secondTempCube = listCube[i - 1];
            if(firstTempCube != null && secondTempCube!= null)
            {
                if (i == listCube.Count - 1)
                {
                    firstTempCube.transform.position = new Vector3(transform.position.x, transform.position.y+firstTempCube.GetComponent<Renderer>().bounds.size.y/2 + cubeGap, transform.position.z);

                }
                else
                {

                    firstTempCube.transform.position = new Vector3(firstTempCube.transform.position.x, firstTempCube.transform.position.y, transform.position.z);

                }
                secondTempCube.transform.position = new Vector3(secondTempCube.transform.position.x, firstTempCube.transform.position.y + firstTempCube.GetComponent<Renderer>().bounds.size.y / 2 + secondTempCube.GetComponent<Renderer>().bounds.size.y / 2 + cubeGap, transform.position.z);
                target = new Vector3(firstTempCube.transform.position.x, secondTempCube.transform.position.y, transform.position.z);
                secondTempCube.transform.position = Vector3.Lerp(secondTempCube.transform.position, target, 0.85F);
            }
        }
    }

    public void OnPointsCube() 
    {
        gameManager.ChangePlayType(PlayType.Finish);
        playerManager.GetComponent<PlayerManager>().enabled = false;
        GetComponent<BoxCollider>().isTrigger= false;
        for (int i = 0; i < listCube.Count; i++)
        {
            firstTempCube = listCube[i];
            firstTempCube.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            firstTempCube.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            firstTempCube.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * (playerManager.GetSpeed() + PlayerPrefs.GetInt(Utils.SPEED_ANIM)) * (listCube.Count-i) * PlayerPrefs.GetInt(Utils.KICK_ANIM, 10));
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.GetPlayType()!=PlayType.Finish)
        {
            PositionChange();
        }
    }
    public void OnLastCube()
    {
        canvasManager.SpeedSliderActive();
        gameManager.ChangePlayType(PlayType.Last);
    }
}
