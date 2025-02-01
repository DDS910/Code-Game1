using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowObjective : MonoBehaviour
{
    public TextMeshProUGUI objective;

    private void Start()
    {
        StartCoroutine(showObjective());
    }

    private IEnumerator showObjective()
    {
        objective.enabled = true;
        yield return new WaitForSecondsRealtime(2f);
        objective.enabled = false;
    }
}
