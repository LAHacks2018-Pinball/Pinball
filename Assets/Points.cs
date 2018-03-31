using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	private float points = 0;

	public void updatePoints(){
		points += 10;
	}

	public float getPoints() {
		return points;
	}
	
	public string stringToEdit = "Score";

}
