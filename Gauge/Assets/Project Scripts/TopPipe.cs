using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPipe : MonoBehaviour

{
	public PipeManager pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PipeManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnMouseDown()
	{
		pm.DownOne((int)transform.position.x,(int)transform.position.y);
	}
}
