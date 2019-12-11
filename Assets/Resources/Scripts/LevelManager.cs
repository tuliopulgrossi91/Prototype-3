﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject Help, Questions, Pause, Settings, Results; // panels
    public GameObject GameOver; // timer 0
    public Text text_Time; // text time
    public Text text_Question, text_Count, text_Result; // text question, count, result
    public Text text_Score, text_Record; // texts score and record
    public static int count_quest; // counter number of questions
    public float count_time; // counter time
    public static bool finish; // check game status
    public static string name_result;
    public static int r; // check random alts

    #region BUTTONS AND PANELS
    public void HelpPanel()
    {
        Help.SetActive(false);
        Questions.SetActive(true);
        Time.timeScale = 1;
    }

    public void QuestionsGame(bool q) => Questions.SetActive(q); // questions game
    public void OnApplicationPause(bool pause)
    {
        Pause.SetActive(pause); // pause game

        if (pause == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void SettingsGame(bool s) => Settings.SetActive(s); // settings game
    public void RetryGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // retry game
    public void BackLevels() => SceneManager.LoadScene(1); // back levels game 
    #endregion

    void Start()
    {
        Time.timeScale = 0;
        count_time = 120f;
        count_quest = 0;
        finish = false;
        Help.SetActive(true);
        QuestList();
        Item.CheckRandom();
        GameOver.SetActive(false);
        Results.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            text_Count.text = "" + count_quest.ToString();
            text_Result.text = name_result;

            #region CHECK TIME GAME
            text_Time.text = Mathf.Round(count_time).ToString();
            count_time -= Time.deltaTime;
            #endregion 
        }
        Debug.Log(count_time);

        #region CHECK FINISH GAME
        if (count_time < 0)
        {
            Time.timeScale = 0;
            Questions.SetActive(false);
            Results.SetActive(true);
            GameOver.SetActive(true);
        }

        if (finish == true && count_time > 0) // game finish - show results
        {
            Time.timeScale = 0;
            Questions.SetActive(false);
            Results.SetActive(true);
        }

        #region CHECK RECORDS
        if (Levels.load == 0)
        {
            if (Levels.score0 > Levels.record0)
            {
                Levels.record0 = Levels.score0;
                PlayerPrefs.SetInt("Record0", Levels.record0);
            }

            text_Score.text = "Pontos: " + Levels.score0.ToString();
            text_Record.text = "Total: " + Levels.record0.ToString();
        }
        if (Levels.load == 1)
        {
            if (Levels.score1 > Levels.record1)
            {
                Levels.record1 = Levels.score1;
                PlayerPrefs.SetInt("Record1", Levels.record1);
            }

            text_Score.text = "Pontos: " + Levels.score1.ToString();
            text_Record.text = "Total: " + Levels.record1.ToString();
        }
        if (Levels.load == 2)
        {
            if (Levels.score2 > Levels.record2)
            {
                Levels.record2 = Levels.score2;
                PlayerPrefs.SetInt("Record2", Levels.record2);
            }

            text_Score.text = "Pontos: " + Levels.score2.ToString();
            text_Record.text = "Total: " + Levels.record2.ToString();
        }
        if (Levels.load == 3)
        {
            if (Levels.score3 > Levels.record3)
            {
                Levels.record3 = Levels.score3;
                PlayerPrefs.SetInt("Record3", Levels.record3);
            }

            text_Score.text = "Pontos: " + Levels.score3.ToString();
            text_Record.text = "Total: " + Levels.record3.ToString();
        }
        if (Levels.load == 4)
        {
            if (Levels.score4 > Levels.record4)
            {
                Levels.record4 = Levels.score4;
                PlayerPrefs.SetInt("Record4", Levels.record4);
            }

            text_Score.text = "Pontos: " + Levels.score4.ToString();
            text_Record.text = "Total: " + Levels.record4.ToString();
        }
        if (Levels.load == 5)
        {
            if (Levels.score5 > Levels.record5)
            {
                Levels.record5 = Levels.score5;
                PlayerPrefs.SetInt("Record5", Levels.record5);
            }

            text_Score.text = "Pontos: " + Levels.score5.ToString();
            text_Record.text = "Total: " + Levels.record5.ToString();
        }
        #endregion
        #endregion

        if (Item.check == true)
        {
            Item.check = false;
            NextQuest();
        }

        if (Item2.check == true)
        {
            Item2.check = false;
            NextQuest();
        }

        if (Item3.check == true)
        {
            Item3.check = false;
            NextQuest();
        }
    }

    void QuestList()
    {
        switch (Levels.load)
        {
            case 0: // Level 0
                text_Question.text = "" + List.numbers[count_quest];
                break;
            case 1: // Level 1
                text_Question.text = "" + List.symbols[count_quest];
                break;
            case 2: // Level 2
                text_Question.text = "" + List.names[count_quest];
                break;
            case 3: // Level 3
                text_Question.text = "" + List.mass[count_quest];
                break;
            case 4: // Level 4
                text_Question.text = "" + List.period[count_quest];
                break;
            case 5: // Level 5
                text_Question.text = "" + List.family[count_quest];
                break;
        }
    }

    void NextQuest()
    {
        // 0 1 2 3 4 5 6 7 8 9
        if (count_quest < 10)
        {
            QuestList();
            Item.CheckRandom();
        }
        if (count_quest == 10)
        {
            finish = true;
        }
    }
}