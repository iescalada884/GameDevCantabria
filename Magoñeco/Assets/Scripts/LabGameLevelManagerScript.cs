using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabGameLevelManagerScript : LevelManagerScript
{
    private PlayerMovementScript Player = null;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        Player.VerticalMovementEnabled = true;
        Player.CanJump= false;
    }

    public void Update()
    {
        SurvivalTimer += Time.deltaTime;

        if (SurvivalTimer >= SurvivalTimeThreshold)
        {
            OnMiniGameEndedDelegate.Invoke(false);
        }
    }
}
