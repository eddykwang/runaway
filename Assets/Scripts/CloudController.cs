using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;


    // Use this for initialization
    void Start () {
        InvokeRepeating("cloudGenerator", 1.0f , Time.deltaTime/0.01f);
	}
	
    void cloudGenerator()
    {
        GameObject couldObj = cloud1;
        int type = Random.Range(1, 4);
        Debug.Log(type);
        switch (type)
        {
           case 1:  couldObj = cloud1; break;
           case 2: couldObj = cloud2; break;
           case 3: couldObj = cloud3; break;
        }
        Instantiate(couldObj);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
