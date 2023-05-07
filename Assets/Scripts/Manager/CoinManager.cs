using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : Singleton<CoinManager>
{
    private int coinCount;
    private CanvasManager canvasManager;

    private void Start()
    {
        canvasManager = CanvasManager.GetInstance();

        coinCount = PlayerPrefs.GetInt(Utils.COIN);
    }
    public void AddCoin(int coin)
    {
        coinCount += coin;
        canvasManager.UpdateCoin();
        UpdateCoin();
    }
    public float GetCoinCount()
    {
        return coinCount;
    }
    public bool LevelUp(float level)
    {

        if (level*10<=coinCount)
        {
            coinCount -= (int)level * 10;
            canvasManager.UpdateCoin();
            UpdateCoin();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateCoin()
    {
        PlayerPrefs.SetInt(Utils.COIN,coinCount);
    }
}
