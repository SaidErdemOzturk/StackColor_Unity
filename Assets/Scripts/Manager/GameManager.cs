using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayType
{
    Awake,
    Start,
    Last,
    Finish
}

public class GameManager : Singleton<GameManager>
{
    private PlayerManager playerManager;
    private CanvasManager canvasManager;
    private PointsManager pointsManager;
    private AnimationManager animationManager;
    private PlayType playType;
    private bool isFinish;
    private float time;
    private float planePoints;

    private void Start()
    {
        playType = PlayType.Awake;
        playerManager = PlayerManager.GetInstance();
        canvasManager = CanvasManager.GetInstance();
        pointsManager = PointsManager.GetInstance();
        animationManager = AnimationManager.GetInstance();
    }

    public void StartGame()
    {
        playType = PlayType.Start;
        playerManager.SetSpeed(PlayerPrefs.GetInt(Utils.SPEED_ANIM, 10));
        animationManager.PushAnim();
        canvasManager.StartButtonChangeActive();
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt(Utils.COIN, ((int)planePoints * pointsManager.GetPoints())+PlayerPrefs.GetInt(Utils.COIN));
        PlayerPrefs.SetInt(Utils.LEVEL,PlayerPrefs.GetInt(Utils.LEVEL)+1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnPointsCube(float planePoints)
    {
        this.planePoints=planePoints;
        isFinish = true;
        time = 10;
    }

    private void Update()
    {
        if (isFinish)
        {
            time = time - Time.deltaTime*5;
            if (time <= 0)
            {
                canvasManager.NextLevelButtonActive();
                isFinish = false;
            }
        }
    }

    private void OnEnable()
    {
        ActionsManager.ChangePlayType += ChangePlayType;
    }

    private void OnDisable()
    {
        ActionsManager.ChangePlayType -= ChangePlayType;
    }

    public void ChangePlayType(PlayType playType)
    {
        this.playType = playType;
    }

    public PlayType GetPlayType()
    {
        return playType;
    }
}
