using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour {

	// Use this for initialization
	private Button button;
	void Start () {
		button = GetComponent<Button>();
		button.onClick.AddListener(Global.LoadSettingsScreen);
	}
}
