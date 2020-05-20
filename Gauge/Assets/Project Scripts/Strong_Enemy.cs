using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strong_Enemy : MonoBehaviour
{
    public Transform player;
    public GameObject playerUnarmed;
    public GameObject playerPistol;
    public GameObject playerRifle;
    public GameObject playerShotgun;
    public GameObject playerMachine;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    public float moveSpeed = 4f;
    public float health = 200;
    public int attackPower = 25;

    public void DamageStrongEnemy(int damage)
    {
        health -= damage;
        animator.SetFloat("Health", health);
        if (health <= 0)
        {
            DieStrongEnemy();
        }
        animator.SetTrigger("Hit");
    }

    void DieStrongEnemy()
    {
        Destroy(gameObject, 0.8f);
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		playerUnarmed = GameObject.Find("Player");
        playerPistol = GameObject.Find("Player_Pistol");
        playerRifle = GameObject.Find("RiflePlayer");
        playerShotgun = GameObject.Find("ShotgunPlayer");
        playerMachine = GameObject.Find("MachinegunPlayer");
		
        if(playerUnarmed != null)
        {
            player = playerUnarmed.transform;
        }
        else if(playerPistol != null)
        {
            player = playerPistol.transform;
        }
        else if (playerRifle != null)
        {
            player = playerRifle.transform;
        }
        else if (playerShotgun != null)
        {
            player = playerShotgun.transform;
        }
        else if (playerMachine != null)
        {
            player = playerMachine.transform;
        }
		
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            animator.SetFloat("Speed", moveSpeed);
            animator.SetFloat("Distance", distance);
            if ((health < 200 && distance > 1.4f) || (distance < 10f && distance > 1.4f))
            {
                moveSpeed = 4f;
                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                direction.Normalize();
                movement = direction;
            }
            else
            {
                moveSpeed = 0f;
            }
        }
    }

    public void DamagePlayer()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.DamagePlayer(attackPower);
        }
    }


    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
