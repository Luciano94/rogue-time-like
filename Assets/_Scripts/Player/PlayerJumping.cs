using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    public float jummpForce = 100.0f;
    public float gravityForce = 50.0f;
    public float jumpTime = 2.0f;

    public LayerMask floorLayer;

    private Rigidbody2D playerRigidbody = null;
    private BoxCollider2D playerCollider = null;

    private Vector2 jumpVector = Vector2.up;

    private void Start()
    {
        if(playerRigidbody == null)
        {
            playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        if(playerRigidbody == null)
        {
            Debug.LogError("You need assing a Rigidbody2D to this object ->" + gameObject.name);
        }

        if (playerCollider == null)
        {
            playerCollider = gameObject.GetComponent<BoxCollider2D>();
        }

        if (playerCollider == null)
        {
            Debug.LogError("You need assing a BoxCollider2D to this object ->" + gameObject.name);
        }
    }


    private void Update()
    {
        if (playerCollider.IsTouchingLayers(floorLayer))
        {
            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(Jump());
            }
        }
    }


    private IEnumerator Jump()
    {
        jumpVector = Vector2.up * jummpForce;
        playerRigidbody.AddForce(jumpVector);

        yield return new WaitForSeconds(jumpTime);

        jumpVector = Vector2.down * gravityForce;
        playerRigidbody.AddForce(jumpVector);
    }
}
