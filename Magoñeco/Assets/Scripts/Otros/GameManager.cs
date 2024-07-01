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
    private AudioSource AudioSource = null;


    private void Awake()
    {
        // Switch to 1920 x 1080 fullscreen at 60 hz
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, new RefreshRate() { numerator = 60, denominator = 1 });

        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject); // Ensure only one instance exists
        DontDestroyOnLoad(gameObject); // Persist across scenes

        AudioSource = GetComponent<AudioSource>();

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
        Debug.Log(miniGameSceneIndexes.Count);

        if (miniGameSceneIndexes.Count <= 1) 
        {
            SceneManager.LoadScene("FinalScene");
        } else
        {
            int RandomListIndex = Random.Range(0, miniGameSceneIndexes.Count);
            int RandomMiniGameSceneIndex = miniGameSceneIndexes[RandomListIndex];
            miniGameSceneIndexes.RemoveAt(RandomListIndex);
            SceneManager.LoadScene(RandomMiniGameSceneIndex);
        }
     
    }

    public void BackToDialogueScene(bool PlayerWon, AudioClip AudioToPlay)
    {
         if (AudioToPlay)
        {
            AudioSource.PlayOneShot(AudioToPlay);
        }

        if (miniGameSceneIndexes.Count != 1)
        {
            ++currentdialoguenumber;
            gano = PlayerWon;

            if (PlayerWon)
                currentStats.victories++;
           
        }
        else {
            if (PlayerWon)
                currentStats.victories++;

            ++currentdialoguenumber;
            gano = currentStats.victories == SceneManager.sceneCountInBuildSettings - 4;
        }

        cambiaEscena("Dialog");
    }
}
