using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
	public GameObject resultLinePrefab;
	public GameObject parentGO;
	public int allTrueAnswersCounter = 0;
	public int allAnswersCounter = 0;
	public List<GameObject> resultLines = new List<GameObject>();
	// Use this for initialization
	void Start () {
		resultLines.Clear();
		CreateLines();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CreateLines()
	{
		for(int x = 0; x <= Global.categoryIndex; x++)
		{
			GameObject newResultLine = Instantiate(resultLinePrefab,parentGO.transform);
			resultLines.Add(newResultLine);
			resultLines[x].GetComponent<ResultLine>().nameCategory.text = Global.categories[x];
			resultLines[x].GetComponent<ResultLine>().trueCounter.text = Global.counterOfTrueAnswers[x].ToString() + "/" + 
			(Global.counterOfTrueAnswers[x]+Global.counterOfFalseAnswers[x]).ToString();
			allTrueAnswersCounter += Global.counterOfTrueAnswers[x];
			allAnswersCounter += Global.counterOfTrueAnswers[x]+Global.counterOfFalseAnswers[x];

			if(x==Global.categoryIndex)
			{
			GameObject newResultLine2 = Instantiate(resultLinePrefab,parentGO.transform);
			resultLines.Add(newResultLine2);
			resultLines[x+1].GetComponent<ResultLine>().nameCategory.text = "Итого:";
			resultLines[x+1].GetComponent<ResultLine>().trueCounter.text = allTrueAnswersCounter.ToString() + "/" + 
			allAnswersCounter.ToString();
			}
		}
		
		
	}
	public void Debugg()
	{
		for(int x = 0; x<=10 ;x++)
		{
			Global.categories.Add(x.ToString());
			Global.counterOfTrueAnswers.Add(x);
			Global.categoryIndex = 10;

		}
	}
}
