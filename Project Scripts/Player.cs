using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health = 300;
    public Slider healthBar;

    public void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DiePlayer();
        }
    }

    void DiePlayer()
    {
        healthBar.value = 0;
        Destroy(gameObject);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
    }
}
