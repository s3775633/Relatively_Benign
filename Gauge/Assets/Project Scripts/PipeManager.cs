using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
	
	[System.Serializable]
	public class Puzzle
	{
		public int width;
		public int height;
		public Pipe[,] pipes;
	}

	public Puzzle puzzle;

	// Use this for initialization
	void Start () {
		Vector2 dimensions = CheckDimensions ();
		puzzle.width = (int)dimensions.x;
		puzzle.height = (int)dimensions.y;
		puzzle.pipes = new Pipe[puzzle.width, puzzle.height];
		foreach (var Pipe in GameObject.FindGameObjectsWithTag("Pipe")) {
			puzzle.pipes [(int)Pipe.transform.position.x, (int)Pipe.transform.position.y] = Pipe.GetComponent<Pipe> ();
		}
	}
	
	Vector2 CheckDimensions()
	{
		Vector2 aux = Vector2.zero;
		GameObject[] pipes = GameObject.FindGameObjectsWithTag ("Pipe");
		foreach (var p in pipes) {
			if (p.transform.position.x > aux.x)
				aux.x = p.transform.position.x;

			if (p.transform.position.y > aux.y)
				aux.y= p.transform.position.y;
		}
		aux.x++;
		aux.y++;
		return aux;
	}
	
	public void DownOne(int w,int h)
	{
		if(string.Equals(puzzle.pipes[w,h-1].imagename,"Pipe_Length")){
			StraightPipe(w,h-1);
		}
		else if(string.Equals(puzzle.pipes[w,h-1].imagename,"Pipe_T")){
			RightOne(w,h-1);
		}
		else if(string.Equals(puzzle.pipes[w,h-1].imagename,"Pipe_T_Left")){
			LeftOne(w,h-1);
		}
		else if(string.Equals(puzzle.pipes[w,h-1].imagename,"Pipe_End")){
			Debug.Log(puzzle.pipes[w,h].imagename);
			Complete(w,h-1);
		}
	}
	
	void StraightPipe(int w,int h)
	{
		Debug.Log(puzzle.pipes[w,h].imagename);
		DownOne(w,h);
	}
	
	void RightOne(int w,int h)
	{
		Debug.Log(puzzle.pipes[w,h].imagename+"0");
		if(string.Equals(puzzle.pipes[w+1,h].imagename,"Pipe_T_Left")){
			DownOne(w+1,h);
		}
		else{
			Across(w,h,w+1);
		}
	}
	
	void LeftOne(int w,int h)
	{
		Debug.Log(puzzle.pipes[w,h].imagename+"4");
		if(string.Equals(puzzle.pipes[w-1,h].imagename,"Pipe_T")){
			DownOne(w-1,h);
		}
		else{
			Across(w,h,w-1);
		}
	}
	
	void Across(int w1,int h,int w2)
	{
		Debug.Log(puzzle.pipes[w1,h].imagename + "1");
		Debug.Log(puzzle.pipes[w2,h].imagename + "2");
		if (w1 < w2){
			RightOne(w2,h);
		}
		if (w1 > w2){
			LeftOne(w2,h);
		}
	}
	
	public void Complete(int w,int h)
	{
		Debug.Log(puzzle.pipes[w,h].imagename);
		Debug.Log(w+","+h);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
