using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFont : MonoBehaviour
{

    private Global.FontSize currentFontSize;
    private Text VisibleTextOnScreen;
    // Use this for initialization
    void Start()
    {
        VisibleTextOnScreen = GetComponent<Text>();
        currentFontSize = Global.fontSize;

        SetFont();

    }

    // Update is called once per frame
    void Update()
    {

        if (currentFontSize != Global.fontSize)
        {
            SetFont();
        }
    }
    void SetFont()
    {
        if (Global.fontSize == Global.FontSize.smallFont)
            {
                VisibleTextOnScreen.fontSize = Global.smallFont;
            }
            else if (Global.fontSize == Global.FontSize.mediumFont)
            {
                VisibleTextOnScreen.fontSize = Global.mediumFont;
            }
            else if (Global.fontSize == Global.FontSize.bigFont)
            {
                VisibleTextOnScreen.fontSize = Global.bigFont;
            }
            currentFontSize = Global.fontSize;
    }
}
