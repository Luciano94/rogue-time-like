using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public LayerMask _targetLayer;
    public Transform Target { get; private set; }
    public bool IsTargetOnSight => Target != null;
    public Vector3? TargetPosition
    {
        get => IsTargetOnSight ? Target.position : (Vector3?) null;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Target = other.transform;
        }
    }

    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Target = null;
        }
    }
}
