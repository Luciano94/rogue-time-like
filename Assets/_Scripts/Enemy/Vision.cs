using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public LayerMask _targetLayer;
    public bool IsTargetOnSight { get; private set; }
    private Transform target;
    public Vector3? TargetPosition
    {
        get => IsTargetOnSight ? target.position : (Vector3?) null;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            IsTargetOnSight = true;
            Debug.LogError("Enter");
        }
    }

    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            IsTargetOnSight = false;
            Debug.LogError("Exit");
        }
    }
}
