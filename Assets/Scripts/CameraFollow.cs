﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;

    public Transform cameraBoundMin;

    public Transform cameraBoundMax;

    float xMin, xMax, yMin, yMax;

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        //Getting transform of object in whiche the camera needs to follow
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        xMin = cameraBoundMin.position.x;
        yMin = cameraBoundMin.position.y;

        xMax = cameraBoundMax.position.x;
        yMax = cameraBoundMax.position.y;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (target.transform.position.y >= transform.position.y)
            {
                transform.position = new Vector3(Mathf.Clamp(0, xMin, xMax),
                Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
            }
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("CameraTarget").GetComponent<Transform>();
        }

        if(target.transform.position.y < transform.position.y - 1.4)
        {
            gm.GoDeath();
        }
    }
}
