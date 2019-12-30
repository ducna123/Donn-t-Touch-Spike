using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour {
    private int d;
	// Use this for initialization
	void Start () {
        d = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject,7f);
    }
}
