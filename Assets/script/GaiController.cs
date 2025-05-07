using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiController : MonoBehaviour
{
    public float speed = 5;

    private float xPos = 0;

    // Use this for initialization
    void Start()
    {
        Vector3 rightEdge =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, Camera.main.nearClipPlane));

        xPos = rightEdge.x + 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        _GaiMovement();
        Destroy(this.gameObject, 2.7f);
    }

    void _GaiMovement()
    {
        if (BirdController.instance.L == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 1f);
        }

        if (Spawn.instance.isSpawn == true)
        {
            //if(transform.position.x > 3)
            //{
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(xPos, 0, 0), Time.deltaTime * 1.5f);
            //}
            if (transform.position.x <= xPos)
            {
                Spawn.instance.isSpawn = false;
            }
        }
    }
}