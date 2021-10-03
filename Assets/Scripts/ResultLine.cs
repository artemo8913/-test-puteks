using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLine : MonoBehaviour {

	public Text nameCategory;
	public Text trueCounter;
	// Use this for initialization
	void Start () {
		nameCategory = GetComponent<Text>();
		trueCounter = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void GetText(string nameOfCategory, int trueAnswers, int falseAnswers)
	{

	}
}
