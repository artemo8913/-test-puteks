using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartTestBtn : MonoBehaviour {

	// Use this for initialization
	private Button button;
	void Start () {
		button = GetComponent<Button>();
		button.onClick.AddListener(Clicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Clicked()
	{
		SceneManager.LoadScene(2);
	}
	//SceneManager.LoadScene(sceneNumberCounter);
}
