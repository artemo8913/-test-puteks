using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleSettingToggle : MonoBehaviour {

	private Toggle toggle;

	void Awake() {
		toggle = GetComponent<Toggle>();
		toggle.isOn = Global.isShuffle;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(toggle.isOn)
		{
			Global.isShuffle = true;
		}
		else
		{
			Global.isShuffle = false;
		}
	}
}
