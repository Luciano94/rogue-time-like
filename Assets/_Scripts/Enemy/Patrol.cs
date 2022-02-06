using UnityEngine;

public class Patrol : IState
{
    [System.Serializable]
    public class Data : AData
    {
        public float Range;
        public float Speed;

        public override IState GenerateInitializedBehaviour() {
            Patrol patrol = new Patrol();
            patrol.Init(this);

            return patrol;
        }
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
        initPosX = data.EntityRef.transform.position.x;
    }

    public void OnExit()
    {
    }

    public void Update()
    {
        float distance = data.Speed * Time.deltaTime;

        if (!data.EntityRef.FacingRight)
        {
            distance *= -1f;
        }

        data.EntityRef.transform.Translate(Vector3.right * distance);

        if (data.EntityRef.transform.position.x > initPosX + halfRange)
        {
            data.EntityRef.FacingRight = false;
        }
        else if (data.EntityRef.transform.position.x < initPosX - halfRange)
        {
            data.EntityRef.FacingRight = true;
        }
    }
}
