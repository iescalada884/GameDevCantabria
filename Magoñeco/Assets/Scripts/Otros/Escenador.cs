using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenador : MonoBehaviour
{


    public void cambiaEscena( string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
