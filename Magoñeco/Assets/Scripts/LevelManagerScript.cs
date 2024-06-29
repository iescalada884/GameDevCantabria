using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public delegate void OnMiniGameEndedDelegateFunc(bool PlayerWon);
    public OnMiniGameEndedDelegateFunc OnMiniGameEndedDelegate;

    private GameManager gameManager;

    public float SurvivalTimeThreshold = 0.0f;
    protected float SurvivalTimer = 0.0f;

    public void Awake()
    {
        OnMiniGameEndedDelegate = OnMiniGameEnded;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnMiniGameEnded(bool PlayerWon)
    {
        gameManager.BackToDialogueScene(PlayerWon);
    }
}
