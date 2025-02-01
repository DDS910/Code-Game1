using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI[] dialogueTexts;
    public TextMeshProUGUI text;
    public float typingspeed;

    private int currentLine = 0;
    public Button finish;

    private bool isTyping = false;
    private Coroutine typingCoroutine;
    private string currentFullText;

    private void Start()
    {
        if (dialogueTexts.Length > 0)
        {
            dialogueTexts[0].gameObject.SetActive(true);
            typingCoroutine = StartCoroutine(TypeText(dialogueTexts[currentLine]));
        }
        text.enabled = true;
    }

    private IEnumerator TypeText(TextMeshProUGUI text)
    {
        isTyping = true; // Mark typing as active
        currentFullText = text.text; // Store the full text
        text.text = ""; // Clear text to start typing

        foreach (char letter in currentFullText)
        {
            text.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }

        isTyping = false; // Typing is complete
        yield return new WaitForSeconds(1.5f);
        newLine();
    }

    private void newLine()
    {
        if (currentLine < dialogueTexts.Length - 1)
        {
            dialogueTexts[currentLine].gameObject.SetActive(false);
            currentLine++;
            dialogueTexts[currentLine].gameObject.SetActive(true);
            typingCoroutine = StartCoroutine(TypeText(dialogueTexts[currentLine]));
        }
        else
        {
            text.enabled = false;
            finish.gameObject.SetActive(true);
        }
    }

    public void finishGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // Fast forward the current text
                StopCoroutine(typingCoroutine);
                dialogueTexts[currentLine].text = currentFullText; // Display the full text of the current line
                isTyping = false;
                newLine();
            }
        }
    }
}
