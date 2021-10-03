using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceRebuild : MonoBehaviour {

    private RectTransform rectTransform;
	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);

    }
}
