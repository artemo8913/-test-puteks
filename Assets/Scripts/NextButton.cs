using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{

    public enum State { ready, steady, go };
    public State nextBtnState = State.ready;
    public Image image;
    public Sprite finish;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (nextBtnState == State.ready)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            gameObject.GetComponent<Image>().raycastTarget = false;
        }
        else if (nextBtnState == State.steady)
        {
            gameObject.GetComponent<Image>().color = Global.colorIsChecking;
            gameObject.GetComponent<Image>().raycastTarget = true;
        }
        else if (nextBtnState == State.go)
        {
            gameObject.GetComponent<Image>().color = Global.colorNextLvl;
            gameObject.GetComponent<Image>().raycastTarget = true;
        }
        if(Global.sceneIndexStatic == Global.finalSceneNumber)
        {
            //Debug.Log(Global.sceneIndexStatic);
            if(nextBtnState == State.go & finish != null)
            {
                image.sprite = finish;
            }
        }
    }
    public void Clicked()
    {
        if (nextBtnState == State.steady)
        {
            nextBtnState = State.go;
            Global.Check();
        }
        else if (nextBtnState == State.go)
        {
            Global.LoadNextLevel();
        }
    }
}
