using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Enemy_Bullet : MonoBehaviour
{
    public Transform player;
    public int damage = 40;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo);
        if (hitInfo.gameObject.GetComponent<Player>())
        {
            Player player = hitInfo.transform.GetComponent<Player>();
            if (player != null)
            {
                player.DamagePlayer(damage);
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
