using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TIMEscript : MonoBehaviour
{
    //public int year = System.DateTime.Now.Year;//год yyyy
    //public int montch = System.DateTime.Now.Month;//месяц MM
    //public int day = System.DateTime.Now.Day;//день dd
    //public int hour = System.DateTime.Now.Hour;//час hh
    //public int minute = System.DateTime.Now.Minute;//минута mm
    //LocationInfo .timestamp в секундах начиная с 1970 года   узнать потом по подробнее
    public int loading_time, cur_time;
    public int minutes;
    public int seconds;
    public bool texts;
    public Text textImageBLOCK, textImageBLOCK2, textImageBLOCK3, textImageBLOCK4;

    float coroutine;
    public bool Menue, Levels;
    int TIMER;
    int textM, textS;
    DateTime epochStart = new DateTime(2016, 8, 20, 0, 0, 0, DateTimeKind.Utc);
    int proverkaREKLAMI;
    string timeFormat;
    void Awake()
    {
        proverkaREKLAMI = PlayerPrefs.GetInt("kupili_reklamu", 0);
        if (proverkaREKLAMI == 0)
        {
            player.PlayerLifes = PlayerPrefs.GetInt("PlayerLifes", 0); TIMER = 60;//1200
            if (player.PlayerLifes < 5)
            {
                cur_time = (int)(DateTime.Now - epochStart).TotalSeconds;
                loading_time = PlayerPrefs.GetInt("loading_time", 0);
                seconds = loading_time - cur_time;

                if (seconds <= -TIMER * 5)
                {
                    player.PlayerLifes = 5;
                    PlayerPrefs.SetInt("PlayerLifes", player.PlayerLifes);
                }
            }
            if (Menue) { coroutine = 1f; }
            if (Levels) { coroutine = 10f; }
          
           TimerMachine(); StartCoroutine(Updateeee()); 
        }
    }

    void TimerMachine()
    {
        if (proverkaREKLAMI == 0)
        {
             player.PlayerLifes = PlayerPrefs.GetInt("PlayerLifes", 0);
            if (player.PlayerLifes >= 5)
            {
                if (texts)
                {
                    textImageBLOCK.text = "";
                    textImageBLOCK2.text = "";
                    textImageBLOCK3.text = "";
                    textImageBLOCK4.text = "";
                }
                cur_time = (int)(DateTime.Now - epochStart).TotalSeconds;
                loading_time = cur_time + TIMER;
                PlayerPrefs.SetInt("loading_time", loading_time);
            }
            else
            {
                cur_time = (int)(DateTime.Now - epochStart).TotalSeconds;
                loading_time = PlayerPrefs.GetInt("loading_time", 0);
            }
        }
    }

    IEnumerator Updateeee()
    {
        while (true)
        {
            if (proverkaREKLAMI == 0)
            {
                if (player.PlayerLifes < 5)
                {
                    cur_time = (int)(DateTime.Now - epochStart).TotalSeconds;
                    minutes = (loading_time - cur_time) / 60;
                    seconds = loading_time - cur_time;
                    if (seconds < 0)
                    {
                        if (seconds > -TIMER && seconds < 0)
                        {
                            player.PlayerLifes += 1; loading_time = cur_time + (TIMER + seconds);
                        }
                        seconds = loading_time - cur_time;
                        if (seconds <= -TIMER) { player.PlayerLifes += 1; loading_time += TIMER; }
                        PlayerPrefs.SetInt("PlayerLifes", player.PlayerLifes);
                        PlayerPrefs.SetInt("loading_time", loading_time);
                        if (player.PlayerLifes >= 5) { TimerMachine(); }
                    }
                    if (seconds == 0)
                    {
                        player.PlayerLifes += 1;
                        PlayerPrefs.SetInt("PlayerLifes", player.PlayerLifes);
                        if (player.PlayerLifes < 5)
                        {
                            TimerMachine();
                        }
                    }
                    if (texts)
                    {
                        textS = (int)Mathf.Floor(seconds % 60);
                        textM = minutes;

                        if (seconds < 10){timeFormat = ":0";}
                        else{timeFormat = ":";}
                        textImageBLOCK.text = textM + timeFormat + textS;
                        textImageBLOCK2.text = textM + timeFormat + textS;
                        textImageBLOCK3.text = textM + timeFormat + textS;
                        textImageBLOCK4.text = textM + timeFormat + textS;
                    }
                }
                PlayerPrefs.SetInt("loading_time", loading_time);
                if (player.PlayerLifes >= 5) { TimerMachine(); }
                yield return new WaitForSeconds(coroutine);
            }
        }
    }

}