using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TijerasGameLevelManagerScript : LevelManagerScript
{
    private PlayerMovementScript Player = null;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        Player.OnPlayerCollisionEnter.AddListener(OnPlayerCollisionEnter);
        Player.JumpLimiter = false;
        Player.CanJump = false;
        Player.VerticalMovementEnabled = false;
    }

    public void Update()
    {
        SurvivalTimer -= Time.deltaTime;
        UpdateCounDownText(SurvivalTimer);
        if (SurvivalTimer <= 0.0f)
        {
            OnMiniGameEndedDelegate.Invoke(true, ClearAudio);
        }
    }

    public void OnPlayerCollisionEnter(GameObject CollidedGameObject)
    {
        if (CollidedGameObject.tag == "Tijeras")
        {
            OnMiniGameEndedDelegate.Invoke(false, DeathAudio);
        }
    }
}
