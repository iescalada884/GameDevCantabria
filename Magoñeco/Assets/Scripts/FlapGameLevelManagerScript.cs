using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlapGameLevelManagerScript : LevelManagerScript
{
    private PlayerMovementScript Player = null;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        Player.OnPlayerCollisionEnter.AddListener(OnPlayerCollisionEnter);
        Player.JumpLimiter = false;
    }

    public void Update()
    {
        SurvivalTimer -= Time.deltaTime;
        UpdateCounDownText(SurvivalTimer);
        if (SurvivalTimer <= 0.0f)
        {
            OnMiniGameEndedDelegate.Invoke(false);
        }
    }

    public void OnPlayerCollisionEnter(GameObject CollidedGameObject)
    {
        if (CollidedGameObject.tag == "Platform")
        {
            OnMiniGameEndedDelegate.Invoke(false);
        }
    }
}
