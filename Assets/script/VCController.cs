using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCController : MonoBehaviour {
    private float z = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, z);
        z += 2;
        Destroy(this.gameObject,3f);

    }
}
