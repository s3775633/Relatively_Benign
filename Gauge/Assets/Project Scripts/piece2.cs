using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piece2 : MonoBehaviour
{
	public float speed;
	public float piperotation = 0;
	public PuzzleManager2 pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PuzzleManager2> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.z != piperotation)
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(0,0,piperotation), speed);
    }
	void OnMouseDown()
	{
		RotatePiece();
		
		pm.WinCheck();
		
	}
	
	public void RotatePiece()
	{
		piperotation += 90;
		if (piperotation == 360)
			piperotation = 0;
		
	}
	public float Getpiperotation(){
		return piperotation;
	}
	

}
