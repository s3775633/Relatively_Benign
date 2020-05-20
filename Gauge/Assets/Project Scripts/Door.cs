using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool locked = true;
	public Animator anim;
	
	public void openDoor(){
		if (locked){
			anim.Play("Open");
		}
		locked = false;
	}
}
