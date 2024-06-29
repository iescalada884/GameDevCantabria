using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class JumpGameLevelManagerScript : LevelManagerScript
{
    private GameObject Player;

    public float YDeathThreshold = 0.0f;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        SurvivalTimer += Time.deltaTime;

        if (SurvivalTimer >= SurvivalTimeThreshold)
        {
            OnMiniGameEndedDelegate.Invoke(true);
        }

        if (Player.transform.position.y <= YDeathThreshold)
        {
            OnMiniGameEndedDelegate.Invoke(false);
        }
    }
}
