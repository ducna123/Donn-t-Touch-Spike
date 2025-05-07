using System;
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
    public GameObject wallLeft, wallRight;

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Vector3 leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, Camera.main.nearClipPlane));
        Vector3 rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, Camera.main.nearClipPlane));

        wallLeft.transform.position = new Vector3(leftEdge.x-0.4f, wallLeft.transform.position.y, wallLeft.transform.position.z);
        wallRight.transform.position = new Vector3(rightEdge.x -0.3f, wallRight.transform.position.y, wallRight.transform.position.z);
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
