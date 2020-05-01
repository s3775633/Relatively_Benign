using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stamina = 2f;

    public Rigidbody2D rb;
    private Camera cam;
    public Animator animator;

    private float recoverTime = 5f;
    private float depleteTimeRun = 3f;
    private float depleteTimeWalk = 7f;
    private float timer = 3f;
    private float timeToWait = 3f;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToWait)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Speed", movement.sqrMagnitude);

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
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
                stamina -= Time.deltaTime / depleteTimeWalk;
                if (stamina <= 0)
                {
                    moveSpeed = 0f;
                    timer = 0;
                }
            }
            else if (movement.sqrMagnitude >= 1 && movement.sqrMagnitude <= 2 && moveSpeed == 10)
            {
                stamina -= Time.deltaTime / depleteTimeRun;
                if (stamina <= 0)
                {
                    moveSpeed = 0f;
                    timer = 0;
                }
            }
            else
            {
                if (stamina <= 2)
                {
                    stamina += Time.deltaTime / recoverTime;
                }
                if (stamina > 2)
                {
                    stamina = 2f;
                }
            }
        }
        else
        {
            if (stamina <= 2)
            {
                stamina += Time.deltaTime / recoverTime;
            }
        }
    }

    IEnumerator waitNow()
    {
        stamina += Time.deltaTime / recoverTime;
        yield return new WaitForSeconds(10);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
