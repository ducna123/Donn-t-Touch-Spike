using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private const string best = "High";
    public AudioSource audio;
    public AudioClip nen;

    void Awake()
    {
        _MakeSingleInstance();
        audio.PlayOneShot(nen);
    }

    private void Update()
    {
        if(audio.isPlaying == false && play.instance.isPlay == false)
        {
            audio.PlayOneShot(nen);
        }
    }

    void _FirstTime()
    {
        if (!PlayerPrefs.HasKey("_FirstTime"))
        {
            PlayerPrefs.SetInt(best, 0);
            PlayerPrefs.SetInt("_FirstTime", 0);
        }
    }

    void _MakeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void _SetBest(int point)
    {
        PlayerPrefs.SetInt(best, point);
    }

    public int _GetBest()
    {
        return PlayerPrefs.GetInt(best);
    }
}
