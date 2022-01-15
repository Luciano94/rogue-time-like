using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform swordPivot = null;
    public float attackVelocity = 1.0f;
    public float attackDuration = 2.0f;

    private float swordRotation = 90.0f; 
    private Vector3 initRotation;
    private bool isAttaking = false;
    private Vector3 newRotation;
    private Vector3 finalRotation;
    private float attackMinDistance = 1.0f; 

    private void Start()
    {
        if (swordPivot == null)
        {
            Debug.LogError("Missing Weapon -> " + gameObject.name);
        }
        else
        {
            initRotation = swordPivot.localEulerAngles;
            swordRotation -= initRotation.z;
            finalRotation = new Vector3(0, 0, swordRotation);
        }
    }

    private void Update()
    {
        if(swordPivot != null)
        {
            if (Input.GetButtonDown("Fire1") && !isAttaking)
            {
                isAttaking = true;
                newRotation = initRotation;
            }

            Attack();
        }
    }

    private void Attack()
    {
        //mover espadita
        if (isAttaking)
        {
            newRotation = Vector3.Lerp(newRotation, finalRotation, (attackVelocity * Time.deltaTime));
            swordPivot.localEulerAngles = newRotation;
           
            float distance = Mathf.Abs(Vector3.Distance(swordPivot.localEulerAngles, finalRotation));
            if(distance < attackMinDistance)
            {
                isAttaking = false;
                swordPivot.localEulerAngles = initRotation;
            }
        }
    }
}
