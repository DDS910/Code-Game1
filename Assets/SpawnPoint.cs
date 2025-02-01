using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject character;
    private GameObject currentPlayer;

    private void Start(){
        character.transform.position = spawnLocation.transform.position;
        character.transform.rotation = spawnLocation.transform.rotation;
    }
}
