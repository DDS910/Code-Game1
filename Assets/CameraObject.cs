using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObject : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public Vector3 offset;
    public Transform[] keys;
    public float durationKeys;
    

    private bool isFollowingPlayer = false;

    private void Start(){
        StartCoroutine(FocusOnKey());
    }

    private void FixedUpdate()
    {
        if (isFollowingPlayer)
        {
            Vector3 desiredPos = player.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, moveSpeed * Time.fixedDeltaTime);
            transform.position = smoothPos;
        }
    }

    private IEnumerator FocusOnKey(){
        foreach (Transform key in keys)
        {
            float elapsedTime = 0f;
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = key.position + offset;

            // Interpolasi posisi kamera ke setiap kunci selama durasi tertentu
            while (elapsedTime < durationKeys)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / durationKeys);
                elapsedTime += Time.deltaTime;
                yield return null; // Tunggu frame berikutnya
            }

            transform.position = targetPosition;
        }
        isFollowingPlayer = true;
    }

    public void setTarget(Transform newPlayer){
        player = newPlayer;
    }
}
