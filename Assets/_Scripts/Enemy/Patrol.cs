using UnityEngine;

public class Patrol : IState
{
    [System.Serializable]
    public class Data
    {
        public float Range;
        public float Speed;
        public Entity entity;
    }

    private Data data;
    private float initPosX;
    private float halfRange;

    public void Init(Data data)
    {
        this.data = data;
        halfRange = data.Range * 0.5f;
    }

    public void FixedUpdate()
    {
    }

    public void OnEnter()
    {
        initPosX = data.entity.transform.position.x;
    }

    public void OnExit()
    {
    }

    public void Update()
    {
        float distance = data.Speed * Time.deltaTime;

        if (!data.entity.FacingRight)
        {
            distance *= -1f;
        }

        data.entity.transform.Translate(Vector3.right * distance);

        if (data.entity.transform.position.x > initPosX + halfRange)
        {
            data.entity.FacingRight = false;
        }
        else if (data.entity.transform.position.x < initPosX - halfRange)
        {
            data.entity.FacingRight = true;
        }
    }
}
