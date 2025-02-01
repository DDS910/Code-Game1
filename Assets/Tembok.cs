using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tembok : MonoBehaviour
{
    public GameObject uiGameover;
    public CharacterMovement controller;

    private void Start()
    {
        uiGameover.SetActive(false);
        controller.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiGameover.SetActive(true);
            Time.timeScale = 0f;
            controller.enabled = false;
        }
    }

    public void Continue(string SceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }

    public void MainMenu(string SceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }
}
