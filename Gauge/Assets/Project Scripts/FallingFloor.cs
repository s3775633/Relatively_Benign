using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    // Start is called before the first frame update

        // set the collision variable
        public Animator animator;
        public AudioSource falling_trap_audio;
        public bool activated;
		private bool done;
        public float timer = 1.0f;

        // Start is called before the first frame update
        void Start()
        {
            animator = this.GetComponent<Animator>();
            falling_trap_audio = this.GetComponent<AudioSource>();
            activated = false;
			done = false;
        }

        private void Update()
        {
            if(activated == true)
            {
                timer -= Time.deltaTime;
            }

            if (timer < 0 )
            {
                animator.SetBool("active", true);
				done = true;
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
		
		public bool isDone(){
			return done;
		}
    }