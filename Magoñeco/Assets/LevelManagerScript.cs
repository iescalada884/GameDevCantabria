using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public delegate void OnMiniGameEndedDelegateFunc(bool PlayerWon);
    public OnMiniGameEndedDelegateFunc OnMiniGameEndedDelegate;

    public float SurvivalTimeThreshold = 0.0f;
    protected float SurvivalTimer = 0.0f;

    public void Awake()
    {
        OnMiniGameEndedDelegate = OnMiniGameEnded;
    }

    public void OnMiniGameEnded(bool PlayerWon)
    {
        if (PlayerWon)
        {
            Debug.Log("ERES UN CRACKELIO");
        }
        else
        {
            Debug.Log("ERES TODO MALO");
        }
    }
}
