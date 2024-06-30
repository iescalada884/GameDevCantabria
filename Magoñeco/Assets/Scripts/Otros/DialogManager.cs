using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using System.IO;
using UnityEngine;


[System.Serializable]
public class Dialogue
{
    public string character;
    public string text;
}

public class DialogueCointainer
{
    public Dialogue[] dialogues;
}

public class DialogManager : MonoBehaviour
{
    //variables
    public bool gano = true;

    public AudioSource[] audioSources;
    public TextMeshProUGUI cuadroDialogo;
    public TextMeshProUGUI personaje;

    private GameManager gameManager;

    public int diaglogue;
    public float textSpeed = 0.1f;


    DialogueCointainer dialogueContainer;
    
    Dialogue[] dialogues;
   
    int index;
    int currentAudioIndex;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gano = gameManager.gano;
    }

    // Start is called before the first frame update
    void Start()
    {
       LoadDialogues(gameManager.currentdialoguenumber);

       StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartDialogue()
    {
        index = 0;

        if (!gano)
            index = 1;

        NextLine();
       
    }

    void LoadDialogues(int id)
    {
        string path = String.Format("dialogues/dialogues{0}", id);

        TextAsset asset = Resources.Load<TextAsset>(path);

        Debug.Log(asset);
        string jsonTextFile = asset.text;

        if (jsonTextFile != null)
        {
            dialogueContainer = JsonUtility.FromJson <DialogueCointainer> (jsonTextFile);
            dialogues = dialogueContainer.dialogues;
        }
        else
        {
            Debug.LogError("No se encontró el archivo de diálogos");
        }
    }

    IEnumerator WriteLine()
    {
        currentAudioIndex = UnityEngine.Random.Range(0, audioSources.Length - 1);
        audioSources[currentAudioIndex].Play();

        foreach (char letter in dialogues[index].text.ToCharArray()) {
            cuadroDialogo.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }

    }

    public void NextLine()
    {
       StopAllCoroutines();
        audioSources[currentAudioIndex].Stop();

        cuadroDialogo.text = String.Empty;

        if (index < dialogues.Length)
        {
            personaje.text = dialogues[index].character;
            StartCoroutine (WriteLine());

            if (index == 0)
            {
                index = 2;
            }
            else
            {
                index++;
            }
        }
        else
        {
            gameManager.LoadRandomMiniGameScene();
        }
    }
}
