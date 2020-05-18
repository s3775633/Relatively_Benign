using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager2 : MonoBehaviour
{
	public GameObject canvas;
	
	[System.Serializable]
	public class Puzzle
	{

		public int width;
		public int height;
		public piece2[,] pieces;
		
	}


	public Puzzle puzzle;


	// Use this for initialization
	void Start () {
	
		canvas.SetActive (false);
		Vector2 dimensions = CheckDimensions ();

		puzzle.width = (int)dimensions.x;
		puzzle.height = (int)dimensions.y;


		puzzle.pieces = new piece2[puzzle.width, puzzle.height];



		foreach (var piece in GameObject.FindGameObjectsWithTag("Piece")) {

			puzzle.pieces [(int)piece.transform.position.x, (int)piece.transform.position.y] = piece.GetComponent<piece2> ();

		}
		
		
		foreach (var item in puzzle.pieces) {
			
			Debug.Log(item.gameObject.name);
			
		}
		Shuffle();
		





	}
	
	void Shuffle()
	{
		foreach (var piece in puzzle.pieces)
		{
			int rand = Random.Range(0,4);
			
			for (int i = 0; i < rand; i++)
			{
				piece.RotatePiece();
			}
		}
	}

	Vector2 CheckDimensions()
	{
		Vector2 aux = Vector2.zero;

		GameObject[] pieces = GameObject.FindGameObjectsWithTag ("Piece");

		foreach (var p in pieces) {
			if (p.transform.position.x > aux.x)
				aux.x = p.transform.position.x;

			if (p.transform.position.y > aux.y)
				aux.y= p.transform.position.y;
		}

		aux.x++;
		aux.y++;

		return aux;
	}
	
	public void WinCheck()
	{
		if(puzzle.pieces [0,4].piperotation == 180){
			if(puzzle.pieces [0,5].piperotation == 0 || puzzle.pieces [0,5].piperotation == 270){
				if(puzzle.pieces [1,5].piperotation == 90|| puzzle.pieces [1,5].piperotation == 270){
					if(puzzle.pieces [2,5].piperotation == 90 || puzzle.pieces [2,5].piperotation == 270){
						if(puzzle.pieces [3,5].piperotation == 180){
							if(puzzle.pieces [3,6].piperotation == 0 || puzzle.pieces [3,6].piperotation == 180){
								if(puzzle.pieces [3,7].piperotation == 0){
									if(puzzle.pieces [4,7].piperotation == 180){
										if(puzzle.pieces [5,8].piperotation == 90 || puzzle.pieces [5,8].piperotation == 270){
											if(puzzle.pieces [6,8].piperotation == 180 || puzzle.pieces [6,8].piperotation == 270){
												if(puzzle.pieces [6,7].piperotation == 180){
													if(puzzle.pieces [5,7].piperotation == 0){
														if(puzzle.pieces [5,6].piperotation == 0 || puzzle.pieces [5,6].piperotation == 180){
															if(puzzle.pieces [5,5].piperotation == 0 || puzzle.pieces [5,5].piperotation == 180){
																if(puzzle.pieces [5,4].piperotation == 0 || puzzle.pieces [5,4].piperotation == 180){
																	if(puzzle.pieces [5,3].piperotation == 0 || puzzle.pieces [5,3].piperotation == 180){
																		if(puzzle.pieces [5,2].piperotation == 90){
																			if(puzzle.pieces [6,2].piperotation == 270){
																				if(puzzle.pieces [6,1].piperotation == 0 || puzzle.pieces [6,1].piperotation == 180){
																					if(puzzle.pieces [7,0].piperotation == 90 || puzzle.pieces [7,0].piperotation == 270){
																						if(puzzle.pieces [8,0].piperotation == 90 || puzzle.pieces [7,0].piperotation == 270){
																							if(puzzle.pieces [9,0].piperotation == 180){
																								if(puzzle.pieces [9,1].piperotation == 0 || puzzle.pieces [9,1].piperotation == 180){
																									if(puzzle.pieces [9,2].piperotation == 270){
																										if(puzzle.pieces [8,2].piperotation == 0 || puzzle.pieces [8,2].piperotation == 180){
																											if(puzzle.pieces [8,3].piperotation == 0 || puzzle.pieces [8,3].piperotation == 180){
																												if(puzzle.pieces [8,4].piperotation == 0 || puzzle.pieces [8,4].piperotation == 180){
																													if(puzzle.pieces [8,5].piperotation == 0){
																														if(puzzle.pieces [9,5].piperotation == 180 || puzzle.pieces [9,5].piperotation == 270){
																															if(puzzle.pieces [9,4].piperotation == 90){
																																Debug.Log("winner");
																																Complete();
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
	

	public void Complete()
	{
		canvas.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
