using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    /*
     * Para llamar desde otros sitios
     * public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }*/

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject); // Ensure only one instance exists
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
