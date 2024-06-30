using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGameLevelManagerScript : LevelManagerScript
{
    private GameObject Player;

    public float XDeathThreshold = 0.0f;
    public float YDeathThreshold = 0.0f;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        SurvivalTimer -= Time.deltaTime;
        UpdateCounDownText(SurvivalTimer);
        if (SurvivalTimer <= 0.0f)
        {
            OnMiniGameEndedDelegate.Invoke(true);
        }

        if (Player.transform.position.x <= XDeathThreshold || Player.transform.position.y <= YDeathThreshold)
        {
            OnMiniGameEndedDelegate.Invoke(false);
        }
    }
}
