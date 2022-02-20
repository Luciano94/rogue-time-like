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

        if (!states.ContainsKey(data)) {
            states.Add(data, data.GenerateInitializedBehaviour());
        }

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
}

public class BasicEnemy : Entity
{
    public Vision EntityVision;
    public Patrol.Data PatrolData;
    public Chase.Data ChaseData;

    private void Awake()
    {
        ChangeCurrentState(PatrolData);
    }


    private void Update()
    {
        if ((CurrState is Patrol) && EntityVision.IsTargetOnSight)
        {
            ChangeCurrentState(ChaseData);
        }
        else if ((CurrState is Chase chase) && chase.LostTrack)
        {
            ChangeCurrentState(PatrolData);
        }

        CurrState.Update();
    }

    
    private void FixedUpdate()
    {
        CurrState.Update();
    }
}
