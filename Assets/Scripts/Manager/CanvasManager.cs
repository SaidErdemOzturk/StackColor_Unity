using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button kickButton;
    [SerializeField] private Button speedButton;
    [SerializeField] private Button scoreButton;
    [SerializeField] private Image speedSlider;
    [SerializeField] private Image coinImage;
    [SerializeField] private TMPro.TextMeshProUGUI pointText;
    [SerializeField] private TMPro.TextMeshProUGUI coinText;
    private CoinManager coinManager;


    void Start()
    {
        coinManager = Singleton<CoinManager>.GetInstance();
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        speedSlider.transform.parent.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
        tryAgainButton.gameObject.SetActive(false);
        kickButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Kick -- "+PlayerPrefs.GetInt(Utils.KICK_ANIM,10).ToString();
        speedButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text="Speed -- "+PlayerPrefs.GetInt(Utils.SPEED_ANIM,10).ToString();
        scoreButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text= "Score -- "+PlayerPrefs.GetFloat(Utils.SCORE_ANIM,5).ToString();
    }
    public void StartButtonChangeActive()
    {
        startButton.gameObject.SetActive(!startButton.gameObject.activeSelf);
    }

    public void NextLevelButtonActive()
    {
        nextLevelButton.gameObject.SetActive(!nextLevelButton.gameObject.activeSelf);
    }

    public void TryAgainButtonActive()
    {
        tryAgainButton.gameObject.SetActive(!tryAgainButton.gameObject.activeSelf);
    }

    public void SpeedSliderActive()
    {
        speedSlider.transform.parent.gameObject.SetActive(!speedSlider.transform.parent.gameObject.activeSelf);
    }

    public void UpdateCoin()
    {
        coinText.text = coinManager.GetCoinCount().ToString();
    }

    public void UpdatePoint(int pointCount)
    {
        pointText.text = pointCount.ToString();
    }

    public void UpdateSlider(float speed)
    {
        speedSlider.fillAmount = speed / 10;
    }

    public void UpdateButtons()
    {
        speedButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Speed -- " + PlayerPrefs.GetInt("Speed", 10).ToString();
        scoreButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Score -- " + PlayerPrefs.GetFloat("Score", 5).ToString();
        kickButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Kick -- " + PlayerPrefs.GetInt("Kick", 10).ToString();
        
    }
}
