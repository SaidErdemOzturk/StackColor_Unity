using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private int kickLevel;
    private int speedLevel;
    private float scoreLevel;
    private CanvasManager canvasManager;
    private CoinManager coinManager;

    private void Start()
    {
        canvasManager = Singleton<CanvasManager>.GetInstance();
        coinManager = Singleton<CoinManager>.GetInstance();
        kickLevel = PlayerPrefs.GetInt(Utils.KICK_ANIM, 10);
        speedLevel = PlayerPrefs.GetInt(Utils.SPEED_ANIM, 10);
        scoreLevel = PlayerPrefs.GetFloat(Utils.SCORE_ANIM, 5);
    }
    public void AddKickPower()
    {
        if (coinManager.LevelUp(kickLevel))
        {
            kickLevel += 1;
            PlayerPrefs.SetInt(Utils.KICK_ANIM, kickLevel);
            canvasManager.UpdateButtons();
        }
    }
    public void AddSpeedPower()
    {
        if (coinManager.LevelUp(speedLevel))
        {
            speedLevel += 1;
            PlayerPrefs.SetInt(Utils.SPEED_ANIM, speedLevel);
            canvasManager.UpdateButtons();

        }
    }
    public void AddScorePlatform()
    {
        if (coinManager.LevelUp(scoreLevel))
        {
            scoreLevel += 0.2F;
            PlayerPrefs.SetFloat(Utils.SCORE_ANIM, scoreLevel);
            canvasManager.UpdateButtons();
        }
    }
}