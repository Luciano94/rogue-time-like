using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TMP_Text timerLife;

    private void Start()
    {
        timerLife = gameObject.GetComponent<TMP_Text>();
        if(timerLife != null)
        {
            LifeSystem.LifeValueChangedEvent += OnlifeChange;
            timerLife.text = "Life: " + Blackboard.Instance.playerLife.ToString();
        }
        else
        {
            Debug.LogError("TimerLife needs a Text component");
        }
    }


    public void OnlifeChange(int life)
    {
        timerLife.text = "Life: " + Blackboard.Instance.playerLife.ToString();
    }
}
