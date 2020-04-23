using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Enemy : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ranged_Enemy_Bullet;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    private float moveSpeed = 2f;
    public float health = 150;
    private int attackPower = 15;
    private float bulletSpeed = 25;
    private float fireRate = 2;
    private float nextFire = -1f;

    public void DamageRangedEnemy(int damage)
    {
        health -= damage;
        animator.SetFloat("Health", health);
        if (health <= 0)
        {
            DieRangedEnemy();
        }
        animator.SetTrigger("Hit");
    }

    void DieRangedEnemy()
    {
        Destroy(gameObject, 1.3f);
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
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            animator.SetFloat("Speed", moveSpeed);
            animator.SetFloat("Distance", distance);
            if ((health < 150 && distance > 6f) || (distance < 10f && distance > 6f))
            {
                moveSpeed = 2f;
                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                direction.Normalize();
                movement = direction;
            }
            else
            {
                moveSpeed = 0f;
                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                direction.Normalize();
                movement = direction;
                if (nextFire > 0)
                {
                    nextFire -= Time.deltaTime;
                    return;
                }
                Shoot();
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

    public void Shoot()
    {
        GameObject bullet1 = Instantiate(ranged_Enemy_Bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        nextFire = fireRate;
    }
}
