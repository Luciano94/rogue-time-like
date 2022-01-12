using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    [Range (0.1f, 200.0f)]
    public float PlayerVelocity = 10.0f;

    private float axisValue = 0.0f;
    private Vector3 moveVector = Vector3.zero;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        if(playerTransform == null)
        {
            playerTransform = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AxisListener();
        Movement();
        Facing();
    }

    private void AxisListener()
    {
        axisValue = Input.GetAxis("Horizontal");
    }

    private void Facing()
    {
        if(axisValue != 0)
        {
            if(axisValue < 0)
            {
                playerTransform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if(axisValue > 0)
            {
                playerTransform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }

    private void Movement()
    {
        if (axisValue != 0)
        {
            moveVector.x = Mathf.Abs(axisValue * PlayerVelocity * Time.deltaTime);
            playerTransform.Translate(moveVector);
        }
    }
}
