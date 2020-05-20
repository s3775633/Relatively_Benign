using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle_Bullet : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public int damage = 80;

    [SerializeField] private AudioClip enemyHit;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo);
        if (hitInfo.gameObject.GetComponent<Fast_Enemy_Behaviour>())
        {
            Fast_Enemy_Behaviour enemy = hitInfo.transform.GetComponent<Fast_Enemy_Behaviour>();
            if (enemy != null)
            {
                enemy.DamageFastEnemy(damage);
                AudioManager.Instance.PlaySFX(enemyHit);
            }
        }
        else if (hitInfo.gameObject.GetComponent<Strong_Enemy>())
        {
            Strong_Enemy enemy = hitInfo.transform.GetComponent<Strong_Enemy>();
            if (enemy != null)
            {
                enemy.DamageStrongEnemy(damage);
                AudioManager.Instance.PlaySFX(enemyHit);
            }
        }
        else if (hitInfo.gameObject.GetComponent<Ranged_Enemy>())
        {
            Ranged_Enemy enemy = hitInfo.transform.GetComponent<Ranged_Enemy>();
            if (enemy != null)
            {
                enemy.DamageRangedEnemy(damage);
                AudioManager.Instance.PlaySFX(enemyHit);
            }
        }
		else if (hitInfo.name == "Walls"){
			Destroy(gameObject);
		}
		
		else if (hitInfo.CompareTag("Door")){
			Destroy(gameObject);
		}
    }

    void Start()
    {
        if (GameObject.Find("RiflePlayer"))
        {
            player = GameObject.Find("RiflePlayer").transform;
        }
    }

    void Update()
    {
        if (GameObject.Find("RiflePlayer"))
        {
            player = GameObject.Find("RiflePlayer").transform;
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance > 30)
            {
                Destroy(gameObject);
            }
        }
    }
}
