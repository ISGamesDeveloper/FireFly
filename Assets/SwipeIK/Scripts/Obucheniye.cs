using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Obucheniye : MonoBehaviour {

    public Text textNACHALO,textNEXT;
    public bool SAMtext1, TargetSwipeLVL2, NEXTneOBUCH;
    public GameObject CancasObucheniye,PALEC,PALEC2,PALEC3;
    public bool Collider1, Collider2,Collider3,Collider4,Collider5,Collider6,Collider7,Collider8,NEXT;//NEXT весит на стрелке NEXT и все в обучении
    public static bool pocazivatPALEC1, pocazivatPALEC2,pocazivatPALEC3;
    int lang;
    void Start()
    {
        lang = PlayerPrefs.GetInt("LANG");
        if (!TargetSwipeLVL2)
        {          
            MainController.instance.uiController.swipeScript.GetComponent<Image>().raycastTarget = false;
            if (lang == 0) { if (NEXT) { textNEXT.text = "ДАЛЕЕ"; textNACHALO.text = "Привет! Сейчас я тебе покажу некоторые хитрости в игре. Проведи пальцем по экрану слева направо."; } }
            else { if (NEXT) { textNEXT.text = "NEXT"; textNACHALO.text = "Hello! Now I will show you some tricks in the game. Swipe your finger across the screen from left to right."; } }
            pocazivatPALEC1 = true;
        }
    }
    public void nextBUTTON()
    {        
        CancasObucheniye.SetActive(false); MainController.instance.uiController.swipeScript.GetComponent<Image>().raycastTarget = true;
        Time.timeScale = 1;
        if (NEXTneOBUCH) { return; }
        if (pocazivatPALEC1) { PALEC.SetActive(true); pocazivatPALEC1 = false; }
        if (pocazivatPALEC2) { PALEC2.SetActive(true); pocazivatPALEC2 = false; }
        if (pocazivatPALEC3) { PALEC3.SetActive(true); pocazivatPALEC3 = false; }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            MainController.instance.uiController.swipeScript.GetComponent<Image>().raycastTarget = false;
            Time.timeScale = 0;
            if (Collider1)
            {
                if (lang == 0) { textNACHALO.text = "Отлично! Это неизвестный бонус. Возьми его."; }
                else { textNACHALO.text = "Excellent! It is unknown bonus. Take him."; }
                    CancasObucheniye.SetActive(true); gameObject.SetActive(false);
            }

            if (Collider2)
            {
                if (lang == 0) { textNACHALO.text = "Этот бонус снижает скорость. Длится бонус всего 15 секунд. Посмотри вниз, там появилась полоска, которая показывает, сколько осталось до восстановления скорости"; }
                else { textNACHALO.text = "This bonus reduces the velocity. Bonus lasts only 15 seconds. Look down, there appeared a strip that shows how much is left up to speed recovery"; }
                CancasObucheniye.SetActive(true); gameObject.SetActive(false);
            }

            if (Collider3) {
                if (lang == 0) { textNACHALO.text = "Этот бонус означает, что управление поменялось местами. Проведи пальцем слева направо, чтобы повернуть назад."; }
                else { textNACHALO.text = "This bonus means that the controls has changed places. Swipe from left to right to turn back"; }
                CancasObucheniye.SetActive(true);pocazivatPALEC2 = true; gameObject.SetActive(false);}

            if (Collider4) {
                if (lang == 0) { textNACHALO.text = "Этот бонус увеличивает твоего светлячка."; }
                else { textNACHALO.text = "This bonus increases your firefly."; }
                CancasObucheniye.SetActive(true); gameObject.SetActive(false); }

            if (Collider5) {
                if (lang == 0) { textNACHALO.text = "Этот знак будет показывать тебе видео, а потом давать тебе 1 броню, которая спасет тебя при столкновении со стеной!"; }
                else { textNACHALO.text = "This sign will show you a video, and then give you 1 armor that will save you in a collision with a wall!"; }
                CancasObucheniye.SetActive(true); gameObject.SetActive(false); }

            if (Collider6) {
                if (lang == 0) { textNACHALO.text = "Удерживай палец на экране, чтобы светлячок двигался быстрее."; }
                else { textNACHALO.text = "Keep your finger on the screen to move faster."; }
                CancasObucheniye.SetActive(true); gameObject.SetActive(false); }
            if (Collider7)
            {
                if (lang == 0) { textNACHALO.text = "Собери 10 монет! 10 монет = 1 броня."; }
                else { textNACHALO.text = "Collect 10 coins! 10 coins = 1 armor."; }
                CancasObucheniye.SetActive(true); gameObject.SetActive(false);
            }
            if (Collider8)
            {
                if (SHITscript.SHITcount>0)
                {
                    if (lang == 0) { textNACHALO.text = "Внимание! Теперь твои 10 монет обменялись на 1 броню. Нажми на экран одновременно двумя пальцами. Твоего светлячка накроет броня для защиты"; }
                    else { textNACHALO.text = "Attention! Now your 10 coins exchanged for 1 armor. Tap the screen with two fingers simultaneously. Your firefly will cover armor for protection"; }
                    CancasObucheniye.SetActive(true); pocazivatPALEC3 = true; gameObject.SetActive(false);
                }
            }
        }
    }
}
