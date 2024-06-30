using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public delegate void OnMiniGameEndedDelegateFunc(bool PlayerWon, AudioClip AudioToPlay);
    public OnMiniGameEndedDelegateFunc OnMiniGameEndedDelegate;

    private GameManager gameManager;

    public TextMeshProUGUI CountDownText;
    public AudioClip ClearAudio;
    public AudioClip DeathAudio;

    public float SurvivalTime = 0.0f;
    protected float SurvivalTimer = 0.0f;

    public void Awake()
    {
        SurvivalTimer = SurvivalTime;
        OnMiniGameEndedDelegate = OnMiniGameEnded;
        CountDownText = GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnMiniGameEnded(bool PlayerWon, AudioClip AudioToPlay)
    {
        gameManager.BackToDialogueScene(PlayerWon, AudioToPlay);
    }

    public void UpdateCounDownText(float SurvivalTimer)
    {
        if (SurvivalTimer <= 5.0f)
        {
            CountDownText.color = Color.red;
        }
        if (SurvivalTimer <= 0.0f)
        {
            SurvivalTimer = 0.0f;
        }
        CountDownText.text = SurvivalTimer.ToString("F2");
    }
}
