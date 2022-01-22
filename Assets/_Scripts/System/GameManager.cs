using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private LifeSystem playerLife;

    private void Awake()
    {
        if (player != null)
        {
            playerLife = player.GetComponent<LifeSystem>();
            playerLife.StartTimer();
            LifeSystem.LifeValueChangedEvent += OnLifeChanged; 
        }
        else
        {
            Debug.LogError("Game Manager needs a reference to Player");
        }
    }

    public void OnLifeChanged(int life)
    {
        if(life <= 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
