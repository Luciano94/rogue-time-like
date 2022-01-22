using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    public static Blackboard instance;
    public static Blackboard Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = new GameObject("Blackboard");
                instance = go.AddComponent<Blackboard>();
            }
            return instance;
        }
    }

    public float playerLife;
}
