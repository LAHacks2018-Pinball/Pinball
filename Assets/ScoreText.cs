using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	public Text textfield;
	public Points pt;

	void Start() {
		textfield.text = "Score:" + pt.getPoints().ToString();
	}

	public void setScoreText() {
		textfield.text = "Score:" + pt.getPoints().ToString();
	}

	void Update(){
		setScoreText();
	}

}
