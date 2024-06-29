using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public int currentdialoguenumber = 1;
    public bool gano = false;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject); // Ensure only one instance exists
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }
    public void cambiaEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void BackToDialogueScene(bool PlayerWon)
    {
        ++currentdialoguenumber;
        gano = PlayerWon;

        cambiaEscena("Dialog");
    }
}
