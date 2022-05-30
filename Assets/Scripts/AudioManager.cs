using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    [Header("Correct")]
    [SerializeField] AudioClip Correct;
    [SerializeField] [Range(0f, 1f)] float CorrectVolume = 1f;

    [Header("Wrong")]
    [SerializeField] AudioClip Wrong;
    [SerializeField] [Range(0f, 1f)] float WrongVolume = 1f;

    [Header("Mute")]
    public Sprite SoundOnImge;
    public Sprite SoundOffImge;
    public Button button;
    private bool SoundIsOn = true;

    public AudioSource audioSource;

    static AudioManager instance;


    void Awake()
    {
        SingletonAudio();
    }

    private void Start()
    {
        SoundOnImge = button.image.sprite;
    }

    void SingletonAudio()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayCorrectClip()
    {
        PlayClip(Correct, CorrectVolume);
    }

    public void PlayWrongClip()
    {
        PlayClip(Wrong, WrongVolume);
    }

    void PlayClip(AudioClip clip, float Volume)
    {
        if (clip != null)
        {
            Vector3 CameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, CameraPos, Volume);
        }
    }

    public void ButtonClicked()
    {
        if(SoundIsOn)
        {
            SoundIsOn = false;
            button.image.sprite = SoundOffImge;
            audioSource.mute = true;
        }
        else
        {
            SoundIsOn = true;
            button.image.sprite = SoundOnImge;
            audioSource.mute = false;
        }
    }

}


