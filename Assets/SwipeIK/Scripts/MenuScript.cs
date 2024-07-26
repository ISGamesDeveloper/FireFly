using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour , IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {

    AudioSource audio;
    public bool PlayGame,EXIT,SITE,SETTINGS,MY_GAMES,STORE,VK;
    public bool BACKvLEVELS, BACKvLEVELS2 , BACKvLEVELS3 , BACKvLEVELS4 , BACKvSETTINGS , BACKvSTORE, MENU;
    public bool NEXTvLEVELS, NEXTvLEVELS2, NEXTvLEVELS3;

    public GameObject CanvasSETTINGS, CanvasGLMENU,CanvasLEVELS, CanvasLEVELS2, CanvasLEVELS3, CanvasLEVELS4, CanvasSTORE,Soobcheniye;
    Text text;
    Image image;
    Color colorCYAN = new Color32(0, 190, 230, 255);
    Color colorGRAY = new Color32(60, 60, 60, 255);
    int lang;
    private int _finishCount, _lifesPlayer;
    void Start()
    {
        audio = GameObject.Find("Object").GetComponent<AudioSource>();
        lang = PlayerPrefs.GetInt("LANG");
    
        _finishCount = PlayerPrefs.GetInt("FINISHcount");
        if (_finishCount < 1) { _finishCount = 1; }
        if (GetComponent<Image>()) { image = GetComponent<Image>(); return; }
        if (GetComponent<Text>()) { text = GetComponent<Text>(); }
        if (MENU) { if (lang == 0) { text.text = "МЕНЮ"; } if (lang == 1) { text.text = "MENU"; } }
        Debug.Log(_finishCount);
        for (int i = 1; i <= 40; i++)
        {
            if (text.text.Equals(i+""))
            {
                if (_finishCount >= i)
                {
                    text.color = colorCYAN;
                }
                else
                {
                    text.color = colorGRAY;
                    text.raycastTarget = false;
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayGame) { CanvasLEVELS.SetActive(true); CanvasGLMENU.SetActive(false); return; }
        if (EXIT) { Application.Quit(); return; }
        if (SITE) { Application.OpenURL("https://www.isgames.ru"); return; };
        if (SETTINGS) { CanvasSETTINGS.SetActive(true); CanvasGLMENU.SetActive(false); return; }
        if (MY_GAMES) { Application.OpenURL("https://play.google.com/store/apps/dev?id=8715971215053349204"); return; };
        if (VK) { Application.OpenURL("https://vk.com/is___games"); return; }

        if (NEXTvLEVELS) { CanvasLEVELS.SetActive(false); CanvasLEVELS2.SetActive(true); return; }
        if (NEXTvLEVELS2) { CanvasLEVELS2.SetActive(false); CanvasLEVELS3.SetActive(true); return; }
        //if (NEXTvLEVELS3) { CanvasLEVELS3.SetActive(false); CanvasLEVELS4.SetActive(true); return; }

        if (BACKvLEVELS || MENU) { CanvasLEVELS.SetActive(false); CanvasLEVELS4.SetActive(false); CanvasGLMENU.SetActive(true); return; }
        if (BACKvLEVELS2) { CanvasLEVELS2.SetActive(false); CanvasLEVELS.SetActive(true); return; }
        if (BACKvLEVELS3) { CanvasLEVELS3.SetActive(false); CanvasLEVELS2.SetActive(true); return; }
       // if (BACKvLEVELS4) { CanvasLEVELS4.SetActive(false); CanvasLEVELS3.SetActive(true); return; }
        if (BACKvSETTINGS) { CanvasSETTINGS.SetActive(false); CanvasGLMENU.SetActive(true); return; }
        if (BACKvSTORE) { CanvasGLMENU.SetActive(true); CanvasSTORE.SetActive(false); return; }
        if (STORE) { CanvasGLMENU.SetActive(false);CanvasSTORE.SetActive(true); return; }
        _lifesPlayer = PlayerPrefs.GetInt("PlayerLifes", 0);

        if (_lifesPlayer > 0)
        {
            for (int i = 1; i <= 40; i++)
            {
                Debug.Log(i);
                if (text.text.Equals("" + i)) { SceneManager.LoadScene("Level" + i); break; }
            }
        }
        else { Soobcheniye.SetActive(true); }
        audio.Play();
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (!SITE && !BACKvLEVELS && !BACKvLEVELS2 && !BACKvLEVELS3 && !BACKvLEVELS4 && !BACKvSETTINGS && !STORE && !BACKvSTORE && !NEXTvLEVELS && !NEXTvLEVELS2 && !NEXTvLEVELS3) { text.color = colorGRAY; }
        if (BACKvLEVELS || BACKvLEVELS2 || BACKvLEVELS3|| BACKvLEVELS4 || BACKvSETTINGS || BACKvSTORE) { image.color = colorGRAY; }
        if (NEXTvLEVELS || NEXTvLEVELS2 || NEXTvLEVELS3) { image.color = colorGRAY; }
        if (STORE) { image.color = colorCYAN; }
    }
    public void OnPointerUp(PointerEventData eventData) {
        if (!SITE && !BACKvLEVELS && !BACKvLEVELS2 && !BACKvLEVELS3 && !BACKvLEVELS4 && !BACKvSETTINGS && !STORE && !BACKvSTORE && !NEXTvLEVELS && !NEXTvLEVELS2 && !NEXTvLEVELS3) { text.color = colorCYAN; }
        if (BACKvLEVELS || BACKvLEVELS2 || BACKvLEVELS3 || BACKvLEVELS4 || BACKvSETTINGS || BACKvSTORE) { image.color = colorCYAN; }
        if (NEXTvLEVELS || NEXTvLEVELS2 || NEXTvLEVELS3) { image.color = colorCYAN; }
        if (STORE) { image.color = colorGRAY; }
        audio.Play();
    }
}
