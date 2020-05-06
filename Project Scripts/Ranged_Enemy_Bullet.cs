using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Enemy_Bullet : MonoBehaviour
{
    public Transform player;
    public GameObject playerUnarmed;
    public GameObject playerPistol;
    public GameObject playerRifle;
    public GameObject playerShotgun;
    public GameObject playerMachine;
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
        playerUnarmed = GameObject.Find("Player");
        playerPistol = GameObject.Find("Player_Pistol");
        playerRifle = GameObject.Find("RiflePlayer");
        playerShotgun = GameObject.Find("ShotgunPlayer");
        playerMachine = GameObject.Find("MachinePlayer");
    }

    void Update()
    {

        if (playerUnarmed)
        {
            player = playerUnarmed.transform;
        }
        else if (playerPistol)
        {
            player = playerPistol.transform;
        }
        else if (playerRifle)
        {
            player = playerRifle.transform;
        }
        else if (playerShotgun)
        {
            player = playerShotgun.transform;
        }
        else if (playerMachine)
        {
            player = playerMachine.transform;
        }
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > 30)
        {
            Destroy(gameObject);
        }
    }
}
