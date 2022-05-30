using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerAndScore : MonoBehaviour
{
    [SerializeField] Image TimerImage;
    [SerializeField] float PlayingTime = 30f;
    [SerializeField] TextMeshProUGUI ScoreCard;
    [SerializeField] Canvas Final;
    [SerializeField] Canvas TimerField;
    [SerializeField] TextMeshProUGUI ScoreCardForGameOver;
    [SerializeField] TextMeshProUGUI FinalScore;
    public AudioSource Audio;
    public Slider VolumeTracker;
    public static TimerAndScore Instance;

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

}


