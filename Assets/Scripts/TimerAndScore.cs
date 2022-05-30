using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerAndScore : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] Image TimerImage;
    [SerializeField] float PlayingTime = 30f;
    [SerializeField] Canvas TimerField;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI ScoreCard;
    [SerializeField] TextMeshProUGUI ScoreCardForGameOver;
    [SerializeField] TextMeshProUGUI FinalScore;
    [SerializeField] Canvas Final;
    [Header("Audio")]
    public AudioSource Audio;
    public Slider VolumeTracker;
    public static TimerAndScore Instance;
    [Header("ObjectsCount")]
    public int Objects;

    private void Awake()
    {
        Instance = this;
    }

    int Score = 0;
 

    float TimerValue;
    

    public float FillTransaction;

    private void Start()
    {
        ScoreCard.text = Score.ToString();
    }

    void Update()
    {
      // open For Timer
        UpdateTimer();
        TimerImage.fillAmount = FillTransaction;
    }

    // Open  /*  For TImer....
    //........................
    //........................
    void UpdateTimer()   
    {
        {
            TimerValue -= Time.deltaTime;

            
                if (TimerValue > 0)
                {
                    FillTransaction = TimerValue / PlayingTime;
                }
                else
                {
                
                TimerValue = PlayingTime;
            }

        if(TimerValue < 0.2)
            {
                Final.gameObject.SetActive(true);
            }
            // Debug.Log(Mathf.RoundToInt(TimerValue));
        }
    }


  public void AddScore( int AddPoint)
    {
        Score += AddPoint;
        Debug.Log("score"+Score);
        ScoreCard.text = Score.ToString();
        ScoreCardForGameOver.text = Score.ToString();
    }

    public void Volume()
    {
        Audio.volume = VolumeTracker.value;
    }

    public void CountObj()
    {
        Objects++;
    }

    public void MinusObjects()
    {
        Objects--;
        if (Objects <= 0)
        {
            Final.gameObject.SetActive(true);
        }
    }
}


