using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsControl : MonoBehaviour
{

    public bool thisButtonWasClicked = false;
    public static bool someButtonWasClicked = false;
    public enum State { indefind, isTrue, isFalse, isChecking };
    public State thisButtonState = State.indefind;
    public NextButton nextButton;
    public bool answerIsTrue = false;
    public Button button;
    public static ButtonsControl[] buttons;
    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }
    // Update is called once per frame
    void Update()
    {
        SetColor();

        //Debug.Log(this.name +"\t\t"+ this.transform.GetSiblingIndex());
    }
    public void Clicked()
    {
        if (Global.isChecked)
        {
            return;
        }
        if (!someButtonWasClicked)
        {
            thisButtonWasClicked = true;
            someButtonWasClicked = true;
            thisButtonState = State.isChecking;


        }
        else if (someButtonWasClicked & !thisButtonWasClicked)
        {
            foreach (ButtonsControl button in buttons)
            {
                if (button.thisButtonWasClicked)
                {
                    button.thisButtonWasClicked = false;
                    button.thisButtonState = State.indefind;
                    thisButtonWasClicked = true;
                    someButtonWasClicked = true;
                    thisButtonState = State.isChecking;
                    break;
                }
            }
        }
        nextButton.nextBtnState = NextButton.State.steady;
    }
    public void SetColor()
    {
        if (thisButtonState == State.indefind)
        {
            gameObject.GetComponent<Image>().color = Global.colorNormal;
        }
        else if (thisButtonState == State.isTrue)
        {
            gameObject.GetComponent<Image>().color = Global.colorTrueAnswer;
        }
        else if (thisButtonState == State.isFalse)
        {
            gameObject.GetComponent<Image>().color = Global.colorFalseAnswer;
        }
        else if (thisButtonState == State.isChecking)
        {
            gameObject.GetComponent<Image>().color = Global.colorIsChecking;
        }
    }
    public void shuffle()
    {
        //Debug.Log(this.transform.GetSiblingIndex() + this.name);

    }
}
