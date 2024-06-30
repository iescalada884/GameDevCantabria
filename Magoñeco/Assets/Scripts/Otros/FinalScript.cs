using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour
{
    private GameManager gameManager;
    private Stats stats;
    private Boolean gano;

    public GameObject derrota; //Default derrota
    public GameObject victoria;
    public GameObject tijeras;
    public TextMeshProUGUI msg;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        stats = gameManager.currentStats;
        gano = gameManager.gano;

        if (gano)
        {
            victoria.SetActive(true);

        }
        else
        {
            derrota.SetActive(true);
            tijeras.SetActive(true);
            msg.SetText(String.Format("No superaste las pruebas ({0}/3), eres defectuoso. ES HORA DEL DESHILACHADOR!!!!!", stats.victories));
        }
    }


}
