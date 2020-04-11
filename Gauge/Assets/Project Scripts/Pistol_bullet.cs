using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_bullet : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Debug.Log(hitInfo);
        if (hitInfo)
        {
            Fast_Enemy_Behaviour enemy = hitInfo.transform.GetComponent<Fast_Enemy_Behaviour>();
            if (enemy != null)
            {
                enemy.DamageFastEnemy(20);
            }
        }
        Destroy(gameObject);
    }

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > 30)
        {
            Destroy(gameObject);
        }
    }
}
