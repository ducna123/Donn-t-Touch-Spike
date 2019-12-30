using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour {
    public bool isPlay;
    public static play instance;

    private void Start()
    {
        _MakeInstance();
        isPlay = false;
    }

    public void _playBT()
    {
        isPlay = true;
        GameManager.instance.audio.Stop();
        SceneManager.LoadScene("Dont");
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}
