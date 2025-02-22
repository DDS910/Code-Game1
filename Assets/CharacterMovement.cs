using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public KeyManager Key;
    public Trap GameOverTrap;
    public Spot GameOverSpot;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(movement.x, movement.y);

        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            Key.keyCount++;
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            GameOverTrap.Lose();
        }

        if (other.gameObject.CompareTag("Spot"))
        {
            GameOverSpot.Lose();
        }
    }

}
