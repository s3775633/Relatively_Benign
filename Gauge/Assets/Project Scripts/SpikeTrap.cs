using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D triggered;
    public Animator animator;
    public AudioSource spike_trap_audio;

    private int trapDamage = 20;

    public Transform player;
    public GameObject playerUnarmed;
    public GameObject playerPistol;
    public GameObject playerRifle;
    public GameObject playerShotgun;
    public GameObject playerMachine;

    public bool activated;
    public float timeTillSpike;
    public bool hit;

    void Start()
    {
        triggered = this.GetComponent<Collider2D>();
        animator = this.GetComponent<Animator>();

        playerUnarmed = GameObject.Find("Player");
        playerPistol = GameObject.Find("Player_Pistol");
        playerRifle = GameObject.Find("RiflePlayer");
        playerShotgun = GameObject.Find("ShotgunPlayer");
        playerMachine = GameObject.Find("MachinegunPlayer");
        player = GameObject.Find("Player").transform;


        spike_trap_audio = this.GetComponent<AudioSource>();
        activated = false;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeTillSpike -= Time.deltaTime;
        
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

        // this bit has to go after the bit telling the trap to go spikey
        if (activated == true && timeTillSpike <= 0)
        {
            hit = true;
            animator.SetBool("triggered", false);
            //below is the variable for changing the delay of the trap. Be warned the animation will need to change to meet the new timing if it gets changed. 
            timeTillSpike = 0.5f;
            
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activated = true;

            if (hit == true)
            {
                DamagePlayer();
                spike_trap_audio.Play();
                hit = false;
                activated = false;
                animator.SetBool("triggered", true);
            }
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


}
