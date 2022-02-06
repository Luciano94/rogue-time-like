using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AData
{
    public Entity EntityRef;
    public abstract IState GenerateInitializedBehaviour();
}

public abstract class Entity : MonoBehaviour
{
    protected Dictionary<AData, IState> states = new Dictionary<AData, IState>();
    protected IState CurrState { get; private set; }

    protected void ChangeCurrentState(AData data)
    {
        CurrState?.OnExit();
        CurrState = states[data];
        CurrState?.OnEnter();
    }

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
    public void AddState(AData data) {
        states.Add(data, data.GenerateInitializedBehaviour());
    }
}

public class BasicEnemy : Entity
{
    public Vision EntityVision;
    public Patrol.Data PatrolData;

    private void Awake()
    {
        AddState(PatrolData);
        ChangeCurrentState(PatrolData);
    }


    private void Update()
    {
        if (EntityVision.IsTargetOnSight)
        {
            Debug.LogError("Targetted");
        }

        CurrState.Update();
    }

    
    private void FixedUpdate()
    {
        CurrState.Update();
    }
}
