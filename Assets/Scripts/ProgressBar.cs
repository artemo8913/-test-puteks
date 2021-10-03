using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	private Image progressBarLine;

	void Start () {
		progressBarLine = GetComponent<Image>();
		progressBarLine.fillAmount = (float) Global.sceneNumberCounter / Global.finalSceneNumber;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
