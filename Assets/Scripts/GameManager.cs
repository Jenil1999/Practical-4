using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  //  public Category GameObj;
    public static GameManager Instance;


    public enum Category
    {
        Food,
        Trekking,
        Electric
    }
    private void Awake()
    {
        Instance = this;
    }

}

