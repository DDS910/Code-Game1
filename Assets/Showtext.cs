using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Showtext : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public CharacterMovement player;
    
    private void Start(){
        player.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        StartCoroutine(showText());
    }

    private IEnumerator showText(){
        

        text1.enabled = true;
        yield return new WaitForSecondsRealtime(3f);
        text1.enabled = false;
        text2.enabled = true;
        yield return new WaitForSecondsRealtime(3f);
        text2.enabled = false;
        text3.enabled = true;
        player.enabled = true;
        yield return new WaitForSecondsRealtime(3f);
        text3.enabled = false;

        
    }

    
}
