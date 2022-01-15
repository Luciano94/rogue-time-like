using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    [Range (0.1f, 200.0f)]
    public float PlayerVelocity = 10.0f;

    private float axisValueX = 0.0f;
    private Vector3 moveVector = Vector3.zero;
    private Transform playerTransform;


    void Start()
    {
        if(playerTransform == null)
        {
            playerTransform = gameObject.transform;
        }
    }


    void Update()
    {
        AxisListener();
        Movement();
        Facing();
    }

    private void AxisListener()
    {
        axisValueX = Input.GetAxis("Horizontal");
    }

    private void Facing()
    {
        if(axisValueX != 0)
        {
            if(axisValueX < 0)
            {
                playerTransform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if(axisValueX > 0)
            {
                playerTransform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }

    private void Movement()
    {
        if (axisValueX != 0)
        {
            moveVector.x = Mathf.Abs(axisValueX * PlayerVelocity * Time.deltaTime);
            playerTransform.Translate(moveVector);
        }
    }
}
