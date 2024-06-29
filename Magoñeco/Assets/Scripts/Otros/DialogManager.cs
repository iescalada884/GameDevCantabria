using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor.ShaderGraph.Serialization;
using System.IO;
using UnityEngine.UI;


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

    public TextMeshProUGUI cuadroDialogo;
    public TextMeshProUGUI personaje;

    public int diaglogue;
    public float textSpeed = 0.1f;
    DialogueCointainer dialogueContainer;
    
     Dialogue[] dialogues;
   
    int index;

// Start is called before the first frame update
void Start()
    {
       LoadDialogues(diaglogue);

       StartDialogue();
       personaje.text = "???";
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
        foreach (char letter in dialogues[index].text.ToCharArray()) {
            cuadroDialogo.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }

    }

    public void NextLine()
    {
       StopAllCoroutines();
        if (index < dialogues.Length)
        {
            cuadroDialogo.text = string.Empty;
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
            gameObject.SetActive(false);
        }
    }
}
