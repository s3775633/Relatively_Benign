using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Test
{
    public Transform firePoint;
    public GameObject bullet;
    public Animator animator;

    public void Shoot(float speed)
    {
        var bullet1 = GameObject.Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
    }
}
