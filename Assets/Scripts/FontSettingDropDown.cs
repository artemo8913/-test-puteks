using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontSettingDropDown : MonoBehaviour {

	private Dropdown dropdown;
	public static int fontValue = 2;
	void Start () {
		dropdown = GetComponent<Dropdown>();
		dropdown.value = fontValue;
	}
	
	// Update is called once per frame
	void Update () {
		fontValue = dropdown.value;
	}
}
