using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KeyManager : MonoBehaviour
{
    public int keyCount;
    public int maxKeys = 5;
    public TilemapCollider2D trigger;
    public TextMeshProUGUI keyText;

    private void Update(){
        keyText.text = "Key Count : " + keyCount.ToString() + " / " + maxKeys.ToString();

        if (keyCount >= maxKeys){
            trigger.isTrigger = true;
        }
        else{
            trigger.isTrigger = false;
        }
    }

}
