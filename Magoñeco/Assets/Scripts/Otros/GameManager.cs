using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public int currentdialoguenumber = 1;
    public bool gano = false;

    private List<int> MiniGameSceneIndexes = new List<int>();

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject); // Ensure only one instance exists
        DontDestroyOnLoad(gameObject); // Persist across scenes

        for (int i = 2; i < SceneManager.sceneCountInBuildSettings; ++i)
        {
            MiniGameSceneIndexes.Add(i);
        }
    }

    public void cambiaEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void LoadRandomMiniGameScene()
    {
        int RandomListIndex = Random.Range(0, MiniGameSceneIndexes.Count);
        int RandomMiniGameSceneIndex = MiniGameSceneIndexes[RandomListIndex];
        MiniGameSceneIndexes.RemoveAt(RandomListIndex);
        SceneManager.LoadScene(RandomMiniGameSceneIndex);
    }

    public void BackToDialogueScene(bool PlayerWon)
    {
        ++currentdialoguenumber;
        gano = PlayerWon;

        cambiaEscena("Dialog");
    }
}
