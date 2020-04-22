using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Space"))
        {
            moveSpeed = 10f;
        }
        else if (Input.GetButtonUp("Space"))
        {
            moveSpeed = 5f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
