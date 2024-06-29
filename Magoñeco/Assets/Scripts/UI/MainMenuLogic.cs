using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    public GameManager gameManager;

    public void PlayGame()
    {
        gameManager.cambiaEscena("Dialog");
    }
}
