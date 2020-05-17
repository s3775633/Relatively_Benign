using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrap : MonoBehaviour
{
    public Collider2D triggered;
    public Animator animator;
    public AudioSource axe_trap_audio;

    int trapDamage = 30;

    public Transform player;
    public GameObject playerUnarmed;
    public GameObject playerPistol;
    public GameObject playerRifle;
    public GameObject playerShotgun;
    public GameObject playerMachine;

    // Start is called before the first frame update
    void Start()
    {
        triggered = this.GetComponent<Collider2D>();
        animator = this.GetComponent<Animator>();
        axe_trap_audio = this.GetComponent<AudioSource>();

        playerUnarmed = GameObject.Find("Player");
        playerPistol = GameObject.Find("Player_Pistol");
        playerRifle = GameObject.Find("RiflePlayer");
        playerShotgun = GameObject.Find("ShotgunPlayer");
        playerMachine = GameObject.Find("MachinegunPlayer");
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerUnarmed.activeSelf)
        {
            player = playerUnarmed.transform;
        }
        else if (playerPistol.activeSelf)
        {
            player = playerPistol.transform;
        }
        else if (playerRifle.activeSelf)
        {
            player = playerRifle.transform;
        }
        else if (playerShotgun.activeSelf)
        {
            player = playerShotgun.transform;
        }
        else if (playerMachine.activeSelf)
        {
            player = playerMachine.transform;
        }
    }

    void DamagePlayer()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.DamagePlayer(trapDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Contact!!!");
        if (other.gameObject.CompareTag("Player"))
        {
            DamagePlayer();
        }
    }
}
