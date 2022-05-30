using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Accessories : MonoBehaviour
{
    public GameObject correctform;
    public GameObject notcorrectform;
    public GameObject notcorrectform1;
    bool moving;

    public GameManager.Category ObjType;

    private void Start()
    {
        CountObjects();
    }

    private void Update()
    {
        if(moving)
        {
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            transform.position = new Vector3(mousepos.x, mousepos.y, transform.position.z);
        }
        
    }

    void CountObjects()
    {
        if (CompareTag("Objects"))
        {
            TimerAndScore.Instance.CountObj();
        }
    }



    private void OnMouseDown()
    {
        {
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            _ = Camera.main.ScreenToWorldPoint(mousepos);
            moving = true;
        }
    }
    
    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(transform.position.x - correctform.transform.position.x) <= 0.6f && Mathf.Abs(transform.position.y - correctform.transform.position.y) <= 0.6f)
        {
            Destroy(gameObject);
        }

        else if (Mathf.Abs(transform.position.x - notcorrectform.transform.position.x) <= 0.6f && Mathf.Abs(transform.position.y - notcorrectform.transform.position.y) <= 0.6f)

        {
           Destroy(gameObject);
        }

        else if(Mathf.Abs(transform.position.x - notcorrectform1.transform.position.x) <= 0.6f && Mathf.Abs(transform.position.y - notcorrectform1.transform.position.y) <= 0.6f)
        {
            Destroy(gameObject);
        }
    }
}