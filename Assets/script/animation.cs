using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour {
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    // Use this for initialization
    void Start () {
		
	}
    float z = 1;
	// Update is called once per frame
	void Update () {
        z += 2;
        a.transform.rotation = Quaternion.Euler(0, 0, z);
        b.transform.rotation = Quaternion.Euler(0, 0, -z);
        c.transform.rotation = Quaternion.Euler(0, 0, z);
        d.transform.rotation = Quaternion.Euler(0, 0, -z);
        e.transform.rotation = Quaternion.Euler(0, 0, -z);
    }
}
