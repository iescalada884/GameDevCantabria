using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{
    //variables
    public TextMeshProUGUI cuadroDialogo;

    public string[] lines;

    public float textSpeed = 0.1f;

    int index;

    // Start is called before the first frame update
    void Start()
    {
       StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartDialogue()
    {
        index = 0;
        Debug.Log("tets");
        StartCoroutine(WriteLine());
    }


    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray()) {
            cuadroDialogo.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }

    }

    public void NextLine()
    {
       StopAllCoroutines();
        if (index < lines.Length - 1)
        {
            index++;

            cuadroDialogo.text = string.Empty;
            StartCoroutine (WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
