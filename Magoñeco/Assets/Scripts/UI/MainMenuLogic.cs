using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    public Escenador escenador;

    public void PlayGame()
    {
        escenador.cambiaEscena("SampleScene");
    }
}
