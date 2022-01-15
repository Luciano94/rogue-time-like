using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followedObj;
    public float lerpOffset = 0.5f;
    public float lerpVelocity = 10.0f;

    private bool needToLerp = false;
    private Vector3 moveVector = Vector3.zero;

    private Vector3 cameraPosition = Vector3.zero;
    private Vector3 followedPosition = Vector3.zero;

    void Start()
    {
        if(followedObj == null)
        {
            Debug.LogError("You must to set a followed obj");
        }

    }

    // Update is called once per frame
    void Update()
    {
        PositionListener();
        CameraMovement();
    }

    private void CameraMovement()
    {

        if (needToLerp)
        {
            Vector3 newposition = Vector3.Lerp(transform.position, followedObj.position, lerpOffset);
            newposition.z = transform.position.z;
            transform.position = newposition;
        }
    }

    private void PositionListener()
    {
        float distance = Mathf.Abs(Vector3.Distance(transform.position, followedObj.position));
        if (distance > lerpOffset)
        {
            needToLerp = true;
        }
        else
        {
            transform.position = followedObj.position;
            needToLerp = false;
        }
    }
}
