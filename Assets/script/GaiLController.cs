using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiLController : MonoBehaviour {
    public float speed = 5;
    // Use this for initialization
    void Start()
    {

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
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
        }
        if (SpawnL.instance.isSpawn == true)
        {
            //if(transform.position.x > 3)
            //{
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3, 0, 0), Time.deltaTime * 1.5f);
            //}
            if (transform.position.x == -3)
            {
                SpawnL.instance.isSpawn = false;
            }
        }
    }
}
