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
   
    AudioManager audioManager;

    /*[SerializeField] TextMeshProUGUI eCountField;
    [SerializeField] TextMeshProUGUI tCountField;*/

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        GetComponent<BoxCollider2D>();
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
                

            }
            else
            {
                TimerAndScore.Instance.AddScore(PointOnWrong);
                audioManager.PlayWrongClip();
                Debug.Log("Incorrect");
                Debug.Log("fAILED");
            }

            collision.gameObject.SetActive(false);
        }
    }

}
