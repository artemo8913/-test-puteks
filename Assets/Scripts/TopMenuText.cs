using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopMenuText : MonoBehaviour {

	public Global global;
	void Start () {
		
	}
	
	void Update () {
		gameObject.GetComponent<Text>().text = global.category + "\n" +"Вопрос "+ global.numberOfQuestion + "/" + global.questionsInCategory;
	}
}
