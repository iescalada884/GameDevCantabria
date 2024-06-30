using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class Stats
{
    public int victories = 0;
    public int levelsUnloked = 0;

}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public int currentdialoguenumber = 1;
    public bool gano = false;
    public Stats currentStats;


    private List<int> miniGameSceneIndexes = new List<int>();

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject); // Ensure only one instance exists
        DontDestroyOnLoad(gameObject); // Persist across scenes

        for (int i = 3; i < SceneManager.sceneCountInBuildSettings; ++i)
        {
            miniGameSceneIndexes.Add(i);
        }

        currentStats = new Stats();
    }

    public void cambiaEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void LoadRandomMiniGameScene()
    {
        if (miniGameSceneIndexes.Count == 0) 
        {
            SceneManager.LoadScene("FinalScene");
        }

        int RandomListIndex = Random.Range(0, miniGameSceneIndexes.Count);
        int RandomMiniGameSceneIndex = miniGameSceneIndexes[RandomListIndex];
        miniGameSceneIndexes.RemoveAt(RandomListIndex);
        SceneManager.LoadScene(RandomMiniGameSceneIndex);
    }

    public void BackToDialogueScene(bool PlayerWon)
    {
        if (miniGameSceneIndexes.Count != 0)
        {
            ++currentdialoguenumber;
            gano = PlayerWon;

            if (PlayerWon)
                currentStats.victories++;
           
        }
        else {
            ++currentdialoguenumber;
            gano = currentStats.victories == SceneManager.sceneCountInBuildSettings - 3;
        }

        cambiaEscena("Dialog");
    }
}
