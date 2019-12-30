using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVC : MonoBehaviour {
    public GameObject v;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float x = Random.Range(1,1000);
        if (x == 1)
        {
            StartCoroutine(spawner());
        }
    }

    IEnumerator spawner()
    {
            yield return new WaitForSeconds(0.01f);
            Vector3 temp = v.transform.position;
            temp.x = Random.Range(-0.8f, 0.8f);
            temp.y = Random.Range(-2.2f, 2.2f);
            //temp.x = 0.8f;
            //temp.y = 2.3f;
            Instantiate(v, temp, Quaternion.identity);
    }
}
