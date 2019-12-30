using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldSpawn : MonoBehaviour {
    public GameObject khien;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (BirdController.instance != null)
        {
            if(BirdController.instance.repondShield == true && BirdController.instance.isAlive == true)
            {
                StartCoroutine(spawner());
                BirdController.instance.repondShield = false;
            }
            
        }
    }
    IEnumerator spawner()
    {
        yield return new WaitForSeconds(0.01f);
        Vector3 temp = khien.transform.position;
        temp.x = Random.Range(-0.8f, 0.8f);
        temp.y = Random.Range(-2.2f, 2.2f);
        Instantiate(khien, temp, Quaternion.identity);
    }
}
