using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public bool FacingRight
    {
        get => transform.localScale.x > 0;
        set
        {
            Vector3 scale = transform.localScale;
            scale.x = value ? 1f : -1f;
            transform.localScale = scale;
        }
    }
}

public class BasicEnemy : Entity
{
    public Vision EntityVision;
    public Patrol.Data PatrolData;
    private IState currState;

    private void ChangeCurrentState<T>(Action<T> init) where T : IState, new()
    {
        currState?.OnExit();
        currState = new T();
        init?.Invoke((T)currState);
        currState?.OnEnter();
    }

    private void Awake()
    {
        ChangeCurrentState<Patrol>(patrol => patrol.Init(PatrolData));
    }


    private void Update()
    {
        if (EntityVision.IsTargetOnSight)
        {
            Debug.LogError("Targetted");
        }

        currState.Update();
    }

    
    private void FixedUpdate()
    {
        currState.Update();
    }
}
