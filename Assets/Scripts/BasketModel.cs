using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasketModel : MonoBehaviour
{
    public GameManager.Category category;

     public int count;
    [Header("Score")]
    [SerializeField] int PointPerPick = 10;
    [SerializeField] int PointOnWrong = 0;

    [SerializeField] TextMeshProUGUI CountField;
    Accessories accessories;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        GetComponent<BoxCollider2D>();
        accessories = GetComponent<Accessories>();
        CountField.text = count.ToString();
        count = 0;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter collider");
        if (collision.gameObject.GetComponent<Accessories>() != null)
        {
            if ((int)category == (int)collision.GetComponent<Accessories>().ObjType)
            {
                Debug.Log("pASS");
                count++;
                CountField.text = count.ToString();
                TimerAndScore.Instance.AddScore(PointPerPick);
                audioManager.PlayCorrectClip();
                Debug.Log("correct");
                TimerAndScore.Instance.MinusObjects();
            }
            else
            {
                TimerAndScore.Instance.AddScore(PointOnWrong);
                audioManager.PlayWrongClip();
                Debug.Log("Incorrect");
                Debug.Log("fAILED");
                TimerAndScore.Instance.MinusObjects();
            }

            collision.gameObject.SetActive(false);
        }
    }

}
