
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour {

	// Use this for initialization
	private Button button;
	void Start () {
		button = GetComponent<Button>();
		button.onClick.AddListener(Global.LoadMainScreen);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//SceneManager.LoadScene(sceneNumberCounter);
}
