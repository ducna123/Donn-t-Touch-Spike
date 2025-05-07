using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiLController : MonoBehaviour {
    public float speed = 5;
    // Use this for initialization
    public bool isLeft;
    private float xPos = 0;
    
    void Start()
    {
        
        Vector3 leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, Camera.main.nearClipPlane));
        Vector3 rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, Camera.main.nearClipPlane));
        
        Debug.Log($"{leftEdge}");
        xPos = isLeft ? leftEdge.x - 0.3f : rightEdge.x + 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        _GaiMovement();
        Destroy(this.gameObject, 2.7f);
    }

    void _GaiMovement()
    {
        if (BirdController.instance.R == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 1f);
        }
        if (SpawnL.instance.isSpawn == true)
        {
            //if(transform.position.x > 3)
            //{
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos, 0, 0), Time.deltaTime * 1.5f);
            //}
            
            if ((transform.position.x >= xPos))
            {
                SpawnL.instance.isSpawn = false;
            }
        }
    }
}
