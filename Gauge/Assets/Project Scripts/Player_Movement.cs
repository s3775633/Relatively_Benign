using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stamina = 200f;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;

    private float recoverTime = 2;
    private float staminaRecover = -1f;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (staminaRecover > 0)
        {
            stamina += 1;
            staminaRecover -= Time.deltaTime;
            return;
        }
        if (Input.GetButton("Space"))
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 5f;
        }
        if (movement.sqrMagnitude >= 1 && movement.sqrMagnitude <= 2 && moveSpeed == 5)
        {
            stamina -= 0.5f;
        }
        else if(movement.sqrMagnitude >= 1 && movement.sqrMagnitude <= 2 && moveSpeed == 10)
        {
            stamina -= 1f;
        }
        else
        {
            if(stamina <= 200)
            {
                stamina += 1;
            }
            if(stamina > 200)
            {
                stamina = 200f;
            }
        }
        if(stamina <= 0f)
        {
            moveSpeed = 0f;
            staminaRecover = recoverTime;
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
