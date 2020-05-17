using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_flame : MonoBehaviour
{
    public BoxCollider2D trap_file_collider;
    public AudioSource trap_fire_audio;
    public GameObject trigger;
    public Animator animator;
    public GameObject player;
    Player player_health;
    TrapTrigger trigger_script;
    public bool running;
    public float timeleft;

    // Start is called before the first frame upadate
    private void Start()
    {
        trigger_script = trigger.GetComponent<TrapTrigger>();
        player_health = player.GetComponent<Player>();
        trap_file_collider = this.GetComponent<BoxCollider2D>();
        animator = this.GetComponent<Animator>();
        trap_fire_audio = this.GetComponent<AudioSource>();
        animator.SetBool("active", false);
    }
    
    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        

        if (trigger_script.activated == true)// && running == false)
        {
            TrapOn();
        }
        else if (trigger_script.activated == true)// && running == true)
        {
            TrapOn();
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
        timeleft = 3.0f;
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

    void OnTriggerStay2D(Collider2D player)
    {
        player_health.DamagePlayer(1);
    }
}
