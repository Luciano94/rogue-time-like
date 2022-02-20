using UnityEngine;

public class Chase : IState
{
    [System.Serializable]
    public class Data : AData
    {
        public float ChaseSpeed;
        public float StopChasingFrame;
        public Vision Vision;

        public override IState GenerateInitializedBehaviour() {
            Chase chase = new Chase();
            chase.Init(this);

            return chase;
        }
    }

    private Data data;
    private Transform initialTarget;
    private float counter;
    public bool LostTrack { get; private set; }

    public void Init(Data data)
    {
        this.data = data;
    }

    public void FixedUpdate()
    {
    }

    public void OnEnter()
    {
        Debug.Assert(data.Vision.Target != null, "No actual target was spotted");
        initialTarget = data.Vision.Target;
        LostTrack = false;
    }

    public void OnExit()
    {
    }

    public void Update()
    {
        if (data.Vision.IsTargetOnSight) {
            counter = data.StopChasingFrame;
        } else {
            counter -= Time.deltaTime;
            if (counter <= 0f) {
                LostTrack = true;
            }
        }
        float dir = Mathf.Sign(initialTarget.position.x - data.EntityRef.transform.position.x);
        if ((dir > 0f) != data.EntityRef.FacingRight) {
            data.EntityRef.FacingRight = !data.EntityRef.FacingRight;
        }

        float dist = dir * data.ChaseSpeed * Time.deltaTime;

        data.EntityRef.transform.Translate(Vector3.right * dist);
    }
}
