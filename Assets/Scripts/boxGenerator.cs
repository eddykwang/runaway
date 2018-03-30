using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxGenerator : MonoBehaviour
{

    public GameObject box;
    public GameObject box2;
    public GameObject box3;
    public float hardLevel = 0.001f;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("cloudGenerator", 0.5f, Time.deltaTime/hardLevel);
    }

    void cloudGenerator()
    {
        GameObject boxObj = box;
        int type = Random.Range(1, 4);
        Debug.Log(type);
        switch (type)
        {
            case 1: boxObj = box; break;
            case 2: boxObj = box2; break;
            case 3: boxObj = box3; break;
        }
        Instantiate(boxObj);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

