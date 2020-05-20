using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public Collider2D trap_file_collider;
    public AudioSource trap_fire_audio;
    public GameObject trigger;
    public Animator animator;
    private int trapDamage = 1;

    public Transform player;
    public GameObject playerUnarmed;
    public GameObject playerPistol;
    public GameObject playerRifle;
    public GameObject playerShotgun;
    public GameObject playerMachine;


    TrapTrigger trigger_script;
    public bool running;
    public float timeleft;

    // Start is called before the first frame upadate
    void Start()
    {
        trigger_script = trigger.GetComponent<TrapTrigger>();

        trap_file_collider = this.GetComponent<Collider2D>();
        animator = this.GetComponent<Animator>();
        trap_fire_audio = this.GetComponent<AudioSource>();
        animator.SetBool("active", false);
    }
    
    // Update is called once per frame
    void Update()
    {
		playerUnarmed = GameObject.Find("Player");
        playerPistol = GameObject.Find("Player_Pistol");
        playerRifle = GameObject.Find("RiflePlayer");
        playerShotgun = GameObject.Find("ShotgunPlayer");
        playerMachine = GameObject.Find("MachinegunPlayer");
		
		if (playerUnarmed != null)
        {
            player = playerUnarmed.transform;
        }
        else if (playerPistol != null)
        {
            player = playerPistol.transform;
        }
        else if (playerRifle != null)
        {
            player = playerRifle.transform;
        }
        else if (playerShotgun != null)
        {
            player = playerShotgun.transform;
        }
        else if (playerMachine != null)
        {
            player = playerMachine.transform;
        }
		
        timeleft -= Time.deltaTime;
              
        if (trigger_script.activated == true && running == false)
        {
            TrapOn();
        }
        else if (trigger_script.activated == true && running == true)
        {
            timeleft = 4.0f;
            //insert code to keep the trap activated. 
        }

        if (timeleft <= 0)
        {
            TrapOff();
        }
    }

    public void TrapOn()
    {
        trap_file_collider.enabled = true;
        trap_fire_audio.Play();
        running = true;
        timeleft = 4.0f;
        animator.SetBool("active", true);
    }

    public void TrapOff()
    {
        trap_file_collider.enabled = false;
        trap_fire_audio.Stop();
        running = false;
        animator.SetBool("active", false);
        timeleft = 0;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DamagePlayer();
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

