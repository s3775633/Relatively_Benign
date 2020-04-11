using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 300;

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
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
