using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    [SerializeField]
    private Text scoreT, endScoreT, bestT;

    [SerializeField]
    private GameObject panelEnd;

    public GameObject panelP;
    public GameObject panelB;

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Awake()
    {
        Time.timeScale = 1;
        _MakeInstance();
    }

    public void _SetPoint(int score)
    {
        scoreT.text = "" + score;
    }


    public void endG(int point)
    {
        panelP.SetActive(false);
        panelB.SetActive(false);
        panelEnd.SetActive(true);
        endScoreT.text = "" + point;
        if (point > GameManager.instance._GetBest())
        {
            GameManager.instance._SetBest(point);
        }
        bestT.text = "" + GameManager.instance._GetBest();
    }

    public void _reS()
    {
        SceneManager.LoadScene("Dont");
    }
    public void _home()
    {
        SceneManager.LoadScene("Menu");
    }
}
