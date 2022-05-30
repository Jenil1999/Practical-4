using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenChanger : MonoBehaviour
{

    public Canvas Setting;
    public Canvas Game;
    public Canvas GameOver;

    public void OpenSetting()
    {
        Setting.gameObject.SetActive(true);
        Game.gameObject.SetActive(false);
    }

    public void GotoGame()
    {
        Setting.gameObject.SetActive(false);
        Game.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Draggy");
    }
}
