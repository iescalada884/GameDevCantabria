using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    private GameManager gameManager;
    private Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        stats = gameManager.currentStats;

    }
}
