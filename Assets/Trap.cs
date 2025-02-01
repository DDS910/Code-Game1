using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Trap : MonoBehaviour
{
    public GameObject[] traps;
    public GameObject gameOver;

    private void Start()
    {
        gameOver.SetActive(false);
        StartCoroutine(trapShow());
    }

    private IEnumerator trapShow()
    {
        while (true)
        {
            foreach (GameObject trap in traps)
            {
                trap.SetActive(false);
            }

            yield return new WaitForSecondsRealtime(3.5f);

            foreach (GameObject trap in traps)
            {
                trap.SetActive(true);
            }

            yield return new WaitForSecondsRealtime(3.5f);
        }

    }

    public void Lose()
    {
        gameOver.SetActive(true);
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
