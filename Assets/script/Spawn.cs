﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;
    public GameObject g5;
    public GameObject g6;
    public GameObject g7;
    public static Spawn instance;
    public float d = 30;
    public bool isSpawn;

    // Use this for initialization
    void Start () {
        d = 20;
        isSpawn = false;
    }

    private void Awake()
    {
        _MakeInstance();
    }

    // Update is called once per frame
    void Update () {
        if (BirdController.instance != null)
        {
            if (BirdController.instance.R == true)
            {
                //d++;
            }
        }
        if (d == 30 && BirdController.instance.firstTime == false)
        {
            StartCoroutine(Spawner());
            d = 0;
        }
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    IEnumerator Spawner()
    {
        float t = Random.Range(1, 7);
        if(t == 1)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 temp = new Vector3(g1.transform.position.x, 0, 0);
            isSpawn = true;
            Instantiate(g1, temp, Quaternion.Euler(0, 0, 90));
        }
        if (t == 2)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 temp = g2.transform.position;
            isSpawn = true;
            Instantiate(g2, temp, Quaternion.Euler(0, 0, 90));
        }
        if (t == 3)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 temp = g3.transform.position;
            isSpawn = true;
            Instantiate(g3, temp, Quaternion.Euler(0, 0, 90));
        }
        if (t == 4)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 temp = g4.transform.position;
            isSpawn = true;
            Instantiate(g4, temp, Quaternion.Euler(0, 0, 90));
        }
        if (t == 5)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 temp = g5.transform.position;
            isSpawn = true;
            Instantiate(g5, temp, Quaternion.Euler(0, 0, 90));
        }
        if (t == 6)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 temp = g6.transform.position;
            isSpawn = true;
            Instantiate(g6, temp, Quaternion.Euler(0, 0, 90));
        }
        if (t == 7)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 temp = g7.transform.position;
            isSpawn = true;
            Instantiate(g7, temp, Quaternion.Euler(0, 0, 90));
        }
        //StartCoroutine(Spawner());
    }

}