using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spot : MonoBehaviour
{
    public GameObject[] sprites1;
    public GameObject[] sprites2;
    public GameObject gameOverUI;

    private void Start()
    {
        foreach (GameObject bandit in sprites2)
        {
            bandit.SetActive(false);
        }

        StartCoroutine(spotCharacter());
    }

    private IEnumerator spotCharacter()
    {
        while (true)
        {
            foreach (GameObject bandit in sprites1)
            {
                bandit.SetActive(true);
            }

            yield return new WaitForSecondsRealtime(3f);

            foreach (GameObject bandit in sprites1)
            {
                bandit.SetActive(false);
            }

            foreach (GameObject bandit in sprites2)
            {
                bandit.SetActive(true);
            }

            yield return new WaitForSecondsRealtime(3f);

            foreach (GameObject bandit in sprites2)
            {
                bandit.SetActive(false);
            }
        }
    }

    public void Lose()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void PlayAgain(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }

    public void ExitMainMenu(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}
