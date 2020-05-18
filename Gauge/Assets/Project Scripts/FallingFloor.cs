using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    // Start is called before the first frame update

        // set the collision variable
        public Collider2D triggered;
        public Animator animator;
        public AudioSource falling_trap_audio;
        public bool activated;
        public float timer = 1.0f;

        // Start is called before the first frame update
        void Start()
        {
            triggered = this.GetComponent<Collider2D>();
            animator = this.GetComponent<Animator>();
            falling_trap_audio = this.GetComponent<AudioSource>();
            activated = false;
        }

        private void Update()
        {
            if(activated == true)
            {
                timer -= Time.deltaTime;
            }

            if (timer <0 )
            {
                animator.SetBool("active", true);
                
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                activated = true;
                falling_trap_audio.Play();

        }
        }

        
    }
