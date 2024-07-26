using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class For_timeScript : MonoBehaviour {

    public static Text timerSecondsUI;
    public GameObject text,SwipeImage;   //Изначально SwipeImage дожно быть выключено. Выключено только в тех уровнях, которые идут на время!!!
    public GameObject PlayerFireFly,UI_and_button_Next,Object_Trigger;
    public static float time,startTime;
    public bool button_NEXT;
    Vector3 triggerPosition;
    public float timers; // если оставить эту переменную = 0 , то переменная time будет = 25.
    int lang;
    public Text textNA_VREMYA;
    private bool start;
	void Awake()
	{
		if (GameObject.Find ("GameObject999")) {PlayerFireFly = GameObject.Find ("GameObject999");} 
	}
	void Start () {
        lang = PlayerPrefs.GetInt("LANG");
        if (button_NEXT)
        {
            var transformText = GameObject.Find("TextNACHALO");
            textNA_VREMYA = transformText.GetComponent<Text>();
            if (lang == 0) { textNA_VREMYA.text = "На время! Найди выход, пока не закончилось время!"; }
            if (lang == 1) { textNA_VREMYA.text = "For a while! Find a way out until it ran out of time!"; }
        }
        if (!button_NEXT)
        {
            if (timers == 0f) { time = 25; }
            if (timers != 0) { time = timers;}
            startTime = time;
            timerSecondsUI = GetComponent<Text>();
            timerSecondsUI.rectTransform.sizeDelta = new Vector2(100, 50);
            triggerPosition = Object_Trigger.transform.position;
            StartCoroutine(timer());
        }
    }
  //   if (Application.loadedLevel == 4) { For_timeScript.time = For_timeScript.startTime; For_timeScript.timerSecondsUI.text = For_timeScript.time + ""; }
    void res()
    {
        if (!button_NEXT)
        {
            time = startTime;
            Object_Trigger.transform.position = triggerPosition;
        }
    }
    public static bool StopTime;

    IEnumerator timer()
    {
        while (time>=0)
        {
            if (!button_NEXT)
            {
                yield return new WaitForSeconds(1f);

                if (time <= 10)
                {
                    timerSecondsUI.color = Color.red;
                    timerSecondsUI.fontSize = 40;
                }
                else
                {
                    timerSecondsUI.color = Color.gray;
                    timerSecondsUI.fontSize = 33;
                }

              
                if (!StopTime)
                {

                    timerSecondsUI.text = "" + time;
                    if (time <= 0) { StopTime = true; timerSecondsUI.text = ""; Object_Trigger.transform.position = PlayerFireFly.transform.position; yield return new WaitForSeconds(2f); StopTime = false; res(); }
                    time -= 1;
                }
            }
        }   
    }

    public void buttonNEXT()
    {
        UI_and_button_Next.SetActive(false);
        text.SetActive(true);
        SwipeImage.SetActive(true);

    }
}
