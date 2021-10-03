using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    //Для управления сценами и их данные
    public static int sceneNumberCounter = 2;
    public static int firstSceneNumber = 2;
    public static int finalSceneNumber = 68;
    public int sceneIndex;
    public static int sceneIndexStatic;
    public string category;
    public int numberOfQuestion;
    public int questionsInCategory;
        public static List<string> categories = new List<string>();
    /*public static string[] categories = new string[]{"ОКЖД","Охрана труда",
    "Оказание первой помощи","Контактная сеть. Общие положения",
    "Арматура контактной сети","Контактная подвеска","Провода и тросы контактной сети",
    "Заземление контактной сети"};*/
    public static int categoryIndex = 0;
    public static List<int> counterOfTrueAnswers = new List<int>();
    public static List<int> counterOfFalseAnswers = new List<int>();

    // Для настроек шрифта
    public enum FontSize { smallFont, mediumFont, bigFont };
    public FontSize inspectorFontSize = FontSize.mediumFont;
    public static FontSize fontSize;
    public static int smallFont = 36;
    public static int mediumFont = 42;
    public static int bigFont = 48;
    // Для настроек цвета
    public static Color colorTrueAnswer = new Color(0f / 255f, 200f / 255f, 0f / 255f);                         //Зелененький
    public static Color colorFalseAnswer = new Color(200f / 255f, 0f / 255f, 0f / 255f);                 //Красненький
    public static Color colorIsChecking = new Color(60f / 255f, 60f / 255f, 246f / 255f);     //Синенький
    public static Color colorNextLvl = new Color(229f / 255f, 124f / 255f, 31f / 255f);                   //Оранжевый
    public static Color colorNormal = new Color(200f / 255f, 200f / 255f, 200f / 255f);                   //Серый
    // Для проверки равильности выбранного ответа
    public static bool CheckResult = false;
    public static bool isChecked = false;
    // Для перемешивания ответов
    public static bool isShuffle = true;
    public static List<int> sibilingIndexies = new List<int>();

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(sceneIndex == firstSceneNumber)
        {
            categories.Clear();
            counterOfTrueAnswers.Clear();
            counterOfFalseAnswers.Clear();
            categories.Add("ОКЖД");
            counterOfTrueAnswers.Add(0);
            counterOfFalseAnswers.Add(0);
            categoryIndex = 0;
        }
        sceneIndexStatic = sceneIndex;
                ButtonsControl.buttons = FindObjectsOfType<ButtonsControl>();
        if(ButtonsControl.buttons!=null & isShuffle)
        {
            Shuffle();
        }
        if(sceneIndex > firstSceneNumber & sceneIndex <= finalSceneNumber)
        {
            if(categories[categories.Count-1] != category)
            {
                categoryIndex++;
                categories.Add(category);
                counterOfTrueAnswers.Add(0);
                counterOfFalseAnswers.Add(0);
            }
        }

    }

    void Update()
    {
        if (FontSettingDropDown.fontValue == 0)
        {
            fontSize = Global.FontSize.smallFont;
        }
        else if (FontSettingDropDown.fontValue == 1)
        {
            fontSize = Global.FontSize.mediumFont;
        }
        else if (FontSettingDropDown.fontValue == 2)
        {
            fontSize = Global.FontSize.bigFont;
        }
        //Debug.Log(isShuffle);
        //Debug.Log(categoryIndex+"\t\t"+counterOfTrueAnswers[categoryIndex]+"\t\t"+counterOfFalseAnswers[categoryIndex]);

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        
    }
    public static void Check()
    {
        foreach (ButtonsControl button in ButtonsControl.buttons)
        {
            if (button.thisButtonWasClicked & button.answerIsTrue)
            {
                button.thisButtonState = ButtonsControl.State.isTrue;
            }
            else if (button.thisButtonWasClicked & !button.answerIsTrue)
            {
                button.thisButtonState = ButtonsControl.State.isFalse;
            }
            else if (!button.thisButtonWasClicked & button.answerIsTrue)
            {
                button.thisButtonState = ButtonsControl.State.isTrue;
            }
            else if (!button.thisButtonWasClicked & !button.answerIsTrue)
            {
                button.thisButtonState = ButtonsControl.State.indefind;
            }

        }
        foreach (ButtonsControl button in ButtonsControl.buttons)
        {
            if (button.thisButtonWasClicked & button.answerIsTrue)
            {
                CheckResult = true;
                counterOfTrueAnswers[categoryIndex]++;
            }
        }
        if(!CheckResult)
        {
           counterOfFalseAnswers[categoryIndex]++; 
        }
        isChecked = true;
    }
    public static void LoadNextLevel()
    {
        isChecked = false;
        CheckResult = false;
        ButtonsControl.someButtonWasClicked = false;
        sceneNumberCounter++;
        SceneManager.LoadScene(sceneNumberCounter);
    }
    public static void LoadMainScreen()
    {
        isChecked = false;
        CheckResult = false;
        ButtonsControl.someButtonWasClicked = false;
        sceneNumberCounter = firstSceneNumber;
        SceneManager.LoadScene(0);
    }
     public static void LoadSettingsScreen()
    {
        isChecked = false;
        CheckResult = false;
        ButtonsControl.someButtonWasClicked = false;
        sceneNumberCounter = firstSceneNumber;
        SceneManager.LoadScene(1);
    }
    
    public static void Shuffle()
    {
        sibilingIndexies.Clear();
        //Собираем значения возможных индексов для данной сцены
        for(int x = 0; x < ButtonsControl.buttons.Length; x++)
        {
            sibilingIndexies.Add(ButtonsControl.buttons[x].transform.GetSiblingIndex());
            //Debug.Log(x + "\t\t" +ButtonsControl.buttons[x].name + "\t\t" + ButtonsControl.buttons[x].transform.GetSiblingIndex());
        }
        //Присваиваем рандомные значения индексов
        for(int x = 0; x < ButtonsControl.buttons.Length; x++)
        {
            int rndmIndex;
            rndmIndex = Random.Range(0,sibilingIndexies.Count);
            //Присваиваем SiblingIndex кнопки с ответом сдучайным образом из списка возможных индексов
            ButtonsControl.buttons[x].transform.SetSiblingIndex(sibilingIndexies[rndmIndex]);
            sibilingIndexies.RemoveAt(rndmIndex);
        }
    }

}
