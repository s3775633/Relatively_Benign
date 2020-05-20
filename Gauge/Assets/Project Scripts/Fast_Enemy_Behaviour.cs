﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast_Enemy_Behaviour : MonoBehaviour
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

    public float moveSpeed = 7f;
    public int health = 100;
    public int attackPower = 10;

    [SerializeField] private AudioClip enemyDeath;
    [SerializeField] private AudioClip enemyAttack;

    public void DamageFastEnemy(int damage)
    {
        health -= damage;
        animator.SetFloat("Health", health);
        if (health <= 0)
        {
            DieFastEnemy();
        }
        animator.SetTrigger("Hit");
    }

    void DieFastEnemy()
    {
        Destroy(gameObject, 0.8f);
        AudioManager.Instance.PlaySFX(enemyDeath);
    }

    void Start()
    {
        player = GameObject.Find("Player").transform;
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
		
        if (playerUnarmed != null)
        {
            player = playerUnarmed.transform;
        }
        else if (playerPistol != null)
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
            if ((health < 100 && distance > 1.4f) || (distance < 10f && distance > 1.4f))
            {
                moveSpeed = 7f;
                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
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
            AudioManager.Instance.PlaySFX(enemyAttack);
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

