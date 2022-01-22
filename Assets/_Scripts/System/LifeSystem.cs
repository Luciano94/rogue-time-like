using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour
{
    public int playerLife = 100;

    public static UnityAction<int> LifeValueChangedEvent;

    private int currentLife;
    private int CurrentLife
    {
        get
        {
            return currentLife;
        }
    }

    public void PLusLife(int value)
    {
        currentLife += value;
    }

    public void MinusLife(int value)
    {
        currentLife -= value;
    }

    public void StartTimer()
    {
        currentLife = playerLife;
        Blackboard.Instance.playerLife = currentLife;
        StartCoroutine("TimerLife");
    }

    private IEnumerator TimerLife()
    {
        yield return new WaitForSeconds(1.0f);

        currentLife -= 1;
        Blackboard.Instance.playerLife = currentLife;

        if(LifeValueChangedEvent != null)
        {
            LifeValueChangedEvent(currentLife);
        }
        
        StartCoroutine("TimerLife");
    }
}
